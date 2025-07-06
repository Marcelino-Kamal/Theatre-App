import { Link } from "react-router-dom";

export default function AdminCards({ data }) {
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const imagePath = data.imgUrl.replace(/\\/g, "/");
  const fullImageUrl = `${baseUrl}${imagePath}`;

  return (
    <Link to={`/adminItem/${data.id}`} className="block">
      <div className="flex flex-col bg-white w-full rounded-2xl m-2 shadow-md overflow- h-[520px]">
        {/* ✅ Image section with fixed height */}
        <div className="w-full h-[390px]">
          <img
            src={fullImageUrl}
            alt={data.name}
            className="w-full h-full object-fill rounded-2xl"
          />
        </div>

        {/* ✅ Text and button section */}
        <div className="flex flex-col items-center justify-between w-full h-full px-4 py-2 gap-2">
          <p className="text-lg font-semibold text-center">{data.name}</p>
          <p className="text-gray-700 text-base">{data.price} LE</p>
          <button
            className="mt-auto px-4 py-2 rounded-2xl font-medium transition w-full bg-[#0C0C0C] text-white hover:bg-[#c55050] cursor-pointer"
          >
            Edit item
          </button>
        </div>
      </div>
    </Link>
  );
}
