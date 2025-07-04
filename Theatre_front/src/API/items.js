import api from "./api";

export const fetchitems = async () => {
  try {
    const response = await api.get("/Items/listItems");
    return response.data;
  } catch (error) {
    if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Failed to fetch items from the server.");
  }
};

export const fetchitemById = async (id) => {

  try{
    const response = await api.get(`/Items/getitem/${id}`)
    return response.data;

  }catch(error){
    if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }
  }
  throw new Error("Failed to fetch items from the server.");


}

export const additem = async (formData) =>{

   const data = new FormData();
    data.append("Name", formData.itemName);
    data.append("Description", formData.description);
    data.append("Price", formData.price);
    data.append("Quantity", formData.quantity);
    data.append("file", formData.file);
    data.append("Catalogue_Id", formData.catalogue);


  try{
    const response = await api.post("/Items/additem",data);
    return response.data;
  }catch(error){
    if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }
  }
  throw new Error("Failed to Add item from the server.");
};