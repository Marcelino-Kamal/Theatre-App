import api from "./api";

export const signUpUser = async (formData) => {
  const form = new FormData();

  form.append("Name", formData.Name);
  form.append("PhoneNumber", formData.PhoneNumber);
  form.append("Password", formData.Password);
  form.append("Confirm", formData.Confirm);
  form.append("NationalId",formData.NationalId);

  try {
    const response = await api.post("/Auth/signup", form);

    return response.data; // { message: "Successfully added" }
  } catch (error) {
    //  Handle ModelState validation errors
    if (error.response?.status === 400 && error.response.data?.errors) {
      const rawErrors = error.response.data.errors;
      const messages = Object.values(rawErrors).flat();
      throw new Error(messages.join("\n"));
    }

    //  Handle custom backend messages (like "Phone Number exists")
    if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Signup failed. Please try again later.");
  }
};

export const signIn = async (formData) => {
  try {
    const response = await api.post("/Auth/signin", formData, {
       
      headers: {
        "Content-Type": "application/json", 
      },
    });

    return response.data;
  } catch (error) {
    if (error.response?.status === 400 && error.response.data?.errors) {
      const rawErrors = error.response.data.errors;
      const messages = Object.values(rawErrors).flat();
      throw new Error(messages.join("\n"));
    }

    if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("SignIn failed. Please try again later.");
  }
};

export const LogOut = async () =>{
  try{
    const response = await api.get("/Auth/logout");
  }catch(error){
     if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Log out failed. Please try again later.");
  }
  
};
