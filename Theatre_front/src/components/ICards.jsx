import { Link } from "react-router-dom";

export default function ICards({ data }) {
  const baseUrl = import.meta.env.VITE_API_BASE_URL;

  const imagePath = data.imgUrl.replace(/\\/g, "/");
  const fullImageUrl = `${baseUrl}${imagePath}`;

  return (
    <Link to={`/iteminfo/${data.id}`} className="block">
    <div className="flex flex-col bg-white w-full rounded-2xl m-[10px] shadow-md overflow-hidden flex-wrap">
      <img src={fullImageUrl} alt={data.name} className="" />
      <div className="flex flex-col items-center w-full">
        <p>{data.name}</p>
        <p>{data.price}</p>
        <button
          disabled={!data.inStock}
          className={`mt-4 px-4 py-2 rounded-2xl font-medium transition ${
            data.inStock
              ? "bg-[#0C0C0C] text-white hover:bg-[#c55050] cursor-pointer"
              : "bg-gray-300 text-gray-500 cursor-not-allowed"
          }`}
          
        >
          Book Now
        </button>
      </div>
    </div>
    </Link>
  );
}
