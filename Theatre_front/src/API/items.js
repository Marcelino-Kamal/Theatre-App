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
