import { useEffect, useState, useRef } from "react";
import { useParams } from "react-router-dom";
import { fetchitemById } from "../../API/items";


export default function AdminItemPage() {
  const { id } = useParams();
  const [Item, setItem] = useState(null);
  const [error, setError] = useState(null);
 
  
  
    useEffect(() => {
    const loadItem = async () => {
      try {
        const result = await fetchitemById(id);
        setItem(result);
      } catch (err) {
        setError(err.message || "Failed to load item.");
      }
    };
    loadItem();
  }, [id]);

  if (error) return <p className="text-red-500 text-center mt-10">{error}</p>;
  if (!Item) return <p className="text-center mt-10">Loading...</p>;

  return (
    <div className="min-h-screen w-full bg-[#D2B48C] flex flex-col items-center py-10 px-4 pt-35">
      <div className="flex flex-col lg:flex-row w-full max-w-6xl gap-10">
        {/* Image Section */}
        <div className="w-full lg:w-1/2 flex justify-center items-center">
          <img
            src={`${import.meta.env.VITE_API_BASE_URL}${Item.imgUrl.replace(
              /\\/g,
              "/"
            )}`}
            alt={Item.name}
            className="w-full max-w-sm h-auto object-cover rounded-2xl"
          />
        </div>

        {/* Details Section */}
        <div className="w-full lg:w-1/2 flex flex-col gap-6">
          <p className="text-3xl lg:text-4xl font-bold">{Item.name}</p>
          <p className="text-lg lg:text-2xl text-gray-800">
            {Item.description}
          </p>
          <p className="text-base lg:text-lg font-bold">
            Price per unit:{" "}
            <span className="text-[#c55050]">{Item.price} LE</span>
          </p>
          <p className="text-base lg:text-lg font-bold">
            In Stock: <span className="text-green-700">{Item.quantity}</span>{" "}
            pieces
          </p>
          {/* Add to Delete Button */}
          <div className="flex">
            <button
              className="w-full py-3 rounded-2xl transition bg-black text-white hover:bg-[#c55050] cursor-pointer">
              Edit Item
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
