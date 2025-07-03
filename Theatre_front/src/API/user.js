import api from "./api";


export const getUser = async () => {

    try{
        const response = await api.get("/user/getuser");
        return response.data;
    }catch (error) {
    if (error.response?.data?.message) {
      throw new Error(error.response.data.message);
    }
    throw new Error("Failed to fetch user from the server.");
  }
};

export const getAllUsers = async () =>{
  try{
    const response = await api.get("/user/getusers")
    return response.data;
  }catch(error){
    if (error.response?.data?.message) {
      throw new Error(error.response.data.message);
    }
    throw new Error("Failed to fetch users from the server.");
  }
}