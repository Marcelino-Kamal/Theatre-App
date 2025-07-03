import { useNavigate } from "react-router-dom";


export default function ManagerDash() {
    const navigate = useNavigate();
  return (
    <div className="w-full min-h-screen bg-[#DA6868] py-10 px-4 flex justify-center items-start pt-24">
      <div className="grid grid-rows-3 mt-24 w-full max-w-xl gap-6 sm:gap-8 md:gap-10">
        <div className="flex justify-between bg-white rounded-xl p-4 shadow">
          <p className="font-semibold text-gray-700">Order List:</p>
            <button className="text-sm sm:text-base text-white px-4 py-2 bg-black hover:bg-[#D2B48C] cursor-pointer rounded-2xl transition" onClick={()=>navigate("/orderlist")}>View Orders</button>
        </div>

        <div className="flex justify-between bg-white rounded-xl p-4 shadow">
          <p className="font-semibold text-gray-700">Product List:</p>
          <button className="text-sm sm:text-base text-white px-4 py-2 bg-black hover:bg-[#D2B48C] cursor-pointer rounded-2xl transition" onClick={()=>navigate("/productlist")}>View Products</button>
        </div>
        <div className="flex justify-between bg-white rounded-xl p-4 shadow">
          <p className="font-semibold text-gray-700">User List:</p>
          <button className="text-sm sm:text-base text-white px-4 py-2 bg-black hover:bg-[#D2B48C] cursor-pointer rounded-2xl transition" onClick={()=>navigate("/userlist")}>View Users</button>
        </div>
      </div>
    </div>
  );
}
