import  { useState } from "react";
import {additem} from "../../../API/items";
import { useNavigate } from "react-router-dom";

export default function AddItem() {
    const [formData, setFormData] = useState({
    itemName: "",
    description: "",
    price: "",
    quantity: "",
    file: null,
    catalogue: "1",
  });
  const navigate = useNavigate();
  const handleChange = (e) => {
    const { name, value, type, checked, files } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: type === "checkbox" ? checked : type === "file" ? files[0] : value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try{
        const res = await additem(formData);
        navigate("/productlist");
        alert(res.message);
    }catch(err){
        alert(err);

    }
  };

  return (
    <div className="p-6 min-h-screen bg-[#D2B48C] mt-10">
      <div className="max-w-3xl mx-auto p-6 bg-white rounded-2xl shadow-md mt-10">
        <h2 className="text-2xl font-semibold mb-6 text-center">
          Add New Item
        </h2>
        <form
          onSubmit={handleSubmit}
          className="grid grid-cols-1 md:grid-cols-2 gap-4"
        >
          {/* Item Name */}
          <div>
            <label className="block mb-1 font-medium">Item Name</label>
            <input
              type="text"
              name="itemName"
              value={formData.itemName}
              onChange={handleChange}
              className="w-full border rounded-xl p-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
              required
            />
          </div>

          {/* Price */}
          <div>
            <label className="block mb-1 font-medium">Price</label>
            <input
              type="number"
              name="price"
              value={formData.price}
              onChange={handleChange}
              className="w-full border rounded-xl p-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
              required
            />
          </div>

          {/* Quantity */}
          <div>
            <label className="block mb-1 font-medium">Quantity</label>
            <input
              type="number"
              name="quantity"
              value={formData.quantity}
              onChange={handleChange}
              className="w-full border rounded-xl p-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
              required
            />
          </div>

          {/* Catalogue */}
          <div>
            <label className="block mb-1 font-medium">Catalogue</label>
            <select
              name="catalogue"
              value={formData.catalogue}
              onChange={handleChange}
              className="w-full border rounded-xl p-2 bg-white focus:outline-none focus:ring-2 focus:ring-blue-500"
              required
            >
              <option value="1">Customs</option>
              <option value="2">Props</option>
            </select>
          </div>

          {/* File Upload */}
          <div className="md:col-span-2">
            <label className="block mb-1 font-medium">Item Image</label>
            <input
              type="file"
              name="file"
              onChange={handleChange}
              accept="image/*"
              className="w-full border rounded-xl p-2"
              required
            />
          </div>

          {/* Description */}
          <div className="md:col-span-2">
            <label className="block mb-1 font-medium">Description</label>
            <textarea
              name="description"
              value={formData.description}
              onChange={handleChange}
              className="w-full border rounded-xl p-2 h-24 resize-none focus:outline-none focus:ring-2 focus:ring-blue-500"
              required
            ></textarea>
          </div>


          {/* Submit */}
          <div className="md:col-span-2 text-center mt-4">
            <button
              type="submit"
              className="bg-blue-600 text-white px-6 py-2 rounded-xl hover:bg-blue-700 transition-all duration-200"
            >
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
