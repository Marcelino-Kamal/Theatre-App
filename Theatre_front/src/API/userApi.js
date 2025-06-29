import api from "./api";

export const signUpUser = async (formData) => {
  const form = new FormData();

  // Keys must match C# DTO properties exactly (PascalCase)
  form.append("Name", formData.Name);
  form.append("PhoneNumber", formData.PhoneNumber);
  form.append("Password", formData.Password);
  form.append("Confirm", formData.Confirm);

  try {
    const response = await api.post("/users/signup", form, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });

    return response.data;
  } catch (error) {
    // Extract validation messages from 400 response
    if (error.response?.status === 400 && error.response.data.errors) {
      const rawErrors = error.response.data.errors;
      const messages = Object.values(rawErrors).flat();
      throw new Error(messages.join("\n")); 
    }

    throw new Error("Signup failed. Please try again later.");
  }
};