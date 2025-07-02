import { useEffect, useState, useRef } from "react";
import { useParams } from "react-router-dom";
import { fetchitemById } from "../../API/items";
import { useCart } from "../../context/CartContext";

export default function ItemPage() {
  const { id } = useParams();
  const [Item, setItem] = useState(null);
  const [error, setError] = useState(null);
  const countRef = useRef();
  const startDateRef = useRef();
  const endDateRef = useRef();
  const { addToCart } = useCart();
  const [isFormValid, setIsFormValid] = useState(false);
  
  const handleAddToCart = () => {
    const count = parseInt(countRef.current.value);
    if (!count || count < 1) return alert("Invalid quantity");

    const product = {
      id: Item.id,
      name: Item.name,
      price: Item.price,
      imageUrl: `${import.meta.env.VITE_API_BASE_URL}${Item.imgUrl.replace(
        /\\/g,
        "/"
      )}`,
      count,
      startDate: startDateRef.current.value,
      endDate: endDateRef.current.value,
    };

    addToCart(product);
    alert("Added to cart!");
  };
  const validateForm = () => {
    const count = parseInt(countRef.current?.value);
    const startDate = new Date(startDateRef.current?.value);
    const endDate = new Date(endDateRef.current?.value);

    const isValidCount = !isNaN(count) && count > 0;
    const areDatesFilled =
      startDateRef.current?.value && endDateRef.current?.value;
    const isDateOrderValid = startDate < endDate;

    setIsFormValid(isValidCount && areDatesFilled && isDateOrderValid);
  };
  useEffect(() => {
  validateForm(); 
}, []);
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
                ref={countRef}
                onChange={validateForm}
                min={1}
                defaultValue={1}
                className="px-4 py-2 rounded-lg border border-gray-300 w-full"
              />
            </div>
            <div className="sm:col-span-2">
              <label htmlFor="StartDate" className="block mb-1 font-medium">
                Start Date:
              </label>
              <input
                id="StartDate"
                name="StartDate"
                ref={startDateRef}
                onChange={validateForm}
                type="date"
                className="px-4 py-2 rounded-lg border border-gray-300 w-full"
              />
              <label htmlFor="EndDate" className="block mb-1 font-medium">
                End Date:
              </label>
              <input
                id="EndDate"
                name="EndDate"
                ref={endDateRef}
                onChange={validateForm}
                type="date"
                className="px-4 py-2 rounded-lg border border-gray-300 w-full"
              />
            </div>
          </div>

          {/* Add to Cart Button */}
          <div className="flex">
            <button
              className={`w-full py-3 rounded-2xl transition ${
                isFormValid
                  ? "bg-black text-white hover:bg-[#c55050] cursor-pointer"
                  : "bg-gray-400 text-white cursor-not-allowed"
              }`}
              disabled={!isFormValid}
              onClick={handleAddToCart}
            >
              Add To Cart
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
