import api from "./api";

export const signUpUser = async (formData) => {
  const form = new FormData();

  form.append("Name", formData.Name);
  form.append("PhoneNumber", formData.PhoneNumber);
  form.append("Password", formData.Password);
  form.append("Confirm", formData.Confirm);

  try {
    const response = await api.post("/Auth/signup", form, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });

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
  const form = new FormData();
  form.append("PhoneNumber", formData.PhoneNumber);
  form.append("Password", formData.Password);

  try {
    const response = await api.post("/Auth/signin", form, {
      headers: {
        "Content-Type": "multipart/form-data",
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
