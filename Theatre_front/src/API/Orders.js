import api from "./api";

export const getOrders = async () =>{

    try{
        const response = await api.get("/order/getorders");
        return response.data;
    }catch(error){
      if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Failed to fetch Orders from the server.");
    }
};