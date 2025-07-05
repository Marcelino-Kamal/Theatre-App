import api from "./api";

export const getOrders = async () => {
  try {
    const response = await api.get("/order/getorders");
    return response.data;
  } catch (error) {
    if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Failed to fetch Orders from the server.");
  }
};

export const addOrder = async (orderData) => {
  try {
    const response = await api.post("/order/addorder", orderData, {
      headers: {
        "Content-Type": "application/json",
      },
    });

    return response.data;
  } catch (error) {
    if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Failed to add order from the server.");
  }
};

export const GetMyOrder = async () =>{

  try{
    const response = await api.get("/order/myorder");
    return response.data;
  }catch(error){
     if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Failed to add order from the server.");
  }

};

export const updateOrderStatus = async (orderData) => {
  try{
    const response = await api.put("/order/updateorder",orderData);
    return response.data;
  }catch(error){
     if (error.response?.status === 400 && error.response.data?.message) {
      throw new Error(error.response.data.message);
    }

    throw new Error("Failed to add order from the server.");
  }
};
