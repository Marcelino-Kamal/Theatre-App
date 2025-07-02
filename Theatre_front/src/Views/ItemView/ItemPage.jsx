import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { fetchitemById } from "../../API/items";

export default function ItemPage() {
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

          {/* Quantity & Date Inputs */}
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
            <div>
              <label htmlFor="count" className="block mb-1 font-medium">
                Quantity needed:
              </label>
              <input
                id="count"
                name="Count"
                type="number"
                min={1}
                defaultValue={1}
                className="px-4 py-2 rounded-lg border border-gray-300 w-full"
              />
            </div>
            <div className="sm:col-span-2">
              <label htmlFor="EndDate" className="block mb-1 font-medium">
                End Date:
              </label>
              <input
                id="EndDate"
                name="EndDate"
                type="date"
                className="px-4 py-2 rounded-lg border border-gray-300 w-full"
              />
              <label htmlFor="StartDate" className="block mb-1 font-medium">
                Start Date:
              </label>
              <input
                id="StartDate"
                name="StartDate"
                type="date"
                className="px-4 py-2 rounded-lg border border-gray-300 w-full"
              />
            </div>
          </div>

          {/* Add to Cart Button */}
          <div className="flex">
            <button className="w-full py-3 text-white bg-black rounded-2xl hover:bg-[#c55050] transition">
              Add To Cart
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
