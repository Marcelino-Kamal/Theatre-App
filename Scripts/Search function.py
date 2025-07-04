import sys
import json
import pandas as pd
import re
import nltk
import numpy as np
from nltk.corpus import stopwords, wordnet
from nltk.tokenize import word_tokenize
from nltk.stem import WordNetLemmatizer, ISRIStemmer
from collections import Counter
from sklearn.feature_extraction.text import TfidfVectorizer
from transformers import BertTokenizer, BertModel
import torch
import pyodbc
# Download NLTK data
nltk.download('punkt')
nltk.download('stopwords')
nltk.download('wordnet')

wnl = WordNetLemmatizer()
arabic_stemmer = ISRIStemmer()
stop_words = set(stopwords.words('english') + stopwords.words('arabic'))

conn_str = (
    "Driver={ODBC Driver 17 for SQL Server};"
    "Server=Marco\\SQLEXPRESS;"
    "Database=Theatre;"
    "Trusted_Connection=yes;"
    "TrustServerCertificate=yes;"
)

conn = pyodbc.connect(conn_str)
query = "SELECT Id, Name, Description, InStock, Price, Quantity, ImgUrl FROM Items"
df = pd.read_sql(query, conn)

def preprocess_text(text):
    text = str(text).lower()
    text = re.sub(r'[^\u0600-\u06FFa-zA-Z\s]', ' ', text)
    tokens = word_tokenize(text)
    result = []
    for word in tokens:
        if word not in stop_words:
            if re.match(r'^[\u0600-\u06FF]', word):  # arabic word
                word = arabic_stemmer.stem(word)
            else:  # english word
                word = wnl.lemmatize(word, "n")
                word = wnl.lemmatize(word, "v")
                word = wnl.lemmatize(word, "a")
            result.append(word)
    return " ".join(result)

df['processed_text'] = df['Description'].apply(preprocess_text)

vectorizer = TfidfVectorizer()

tokenizer = BertTokenizer.from_pretrained('bert-base-multilingual-cased')
model = BertModel.from_pretrained('bert-base-multilingual-cased')

def expand_query_with_feedback(query, top_docs, num_terms=5):
    words = []
    for doc in top_docs:
        words.extend(doc['processed_text'].split())
    term_counts = Counter(words)
    common_terms = [term for term, _ in term_counts.most_common(num_terms)]
    return query + " " + " ".join(common_terms)

def expand_query_with_synonyms(query, num_synonyms=3):
    query_terms = query.split()
    expanded_terms = []
    for term in query_terms:
        if re.match(r'^[a-z]', term):  
            synonyms = set()
            for syn in wordnet.synsets(term):
                for lemma in syn.lemmas():
                    synonyms.add(lemma.name())
            expanded_terms.append(" ".join(list(synonyms)[:num_synonyms]))
        else:
            expanded_terms.append(term)
    return " ".join(expanded_terms)

def expand_query_with_bert(query):
    inputs = tokenizer(query, return_tensors="pt", truncation=True, max_length=128)
    outputs = model(**inputs)
    _ = outputs.last_hidden_state.mean(dim=1) 
    return query

def rank_documents(query, documents):
    tfidf_matrix = vectorizer.fit_transform(documents)
    query_vector = vectorizer.transform([query])
    cosine_sim = np.dot(tfidf_matrix, query_vector.T).toarray().flatten()
    ranked_indices = cosine_sim.argsort()[::-1]
    return ranked_indices, cosine_sim

def search_term(query, top_docs_count=5, feedback_terms=5, synonym_count=3):
    query = preprocess_text(query)
    documents = df["processed_text"].tolist()

    initial_ranked_indices, _ = rank_documents(query, documents)
    top_docs = [df.iloc[i] for i in initial_ranked_indices[:top_docs_count]]

    query = expand_query_with_feedback(query, top_docs, feedback_terms)
    query = expand_query_with_synonyms(query, synonym_count)
    query = expand_query_with_bert(query)

    final_indices, scores = rank_documents(query, documents)

    results = {}
    for idx in final_indices:
        doc_id = df.iloc[idx]['Id']
        results[doc_id] = float(scores[idx])
    return results
    
    if __name__ == "__main__":
    input_text = sys.argv[1]
    result = search_term(input_text)
    print(json.dumps(result))