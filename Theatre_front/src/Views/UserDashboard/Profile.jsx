import { useState,useEffect } from "react";
import { getUser} from "../../API/user";

export default function Profile() {

  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const data = await getUser(); 
         console.log("Fetched User:", data); 
        setUser(data);
      } catch (err) {
        setError(err.message || "Error loading user");
      }
    };

    fetchUser();
  }, []);
  if (!user) {
  return <div className="text-white text-xl">Loading user info...</div>;
}

  return (
    <div className="w-full min-h-screen bg-[#DA6868] py-10 px-4 flex justify-center items-start pt-24">
      <div className="grid grid-rows-3 w-full max-w-xl gap-6 sm:gap-8 md:gap-10">
        <div className="flex flex-col sm:flex-row sm:items-center justify-between">
          <p className="text-lg sm:text-xl font-semibold text-white">User Details</p>
          <button className="mt-4 sm:mt-0 text-sm sm:text-base text-white px-4 py-2 bg-black hover:bg-[#D2B48C] cursor-pointer rounded-2xl transition">
            Edit Info
          </button>
        </div>

        <div className="flex flex-col bg-white rounded-xl p-4 shadow">
          <p className="font-semibold text-gray-700">User Name:</p>
          <p className="text-gray-900">{user.name}</p>
        </div>

        <div className="flex flex-col bg-white rounded-xl p-4 shadow">
          <p className="font-semibold text-gray-700">Phone Number:</p>
          <p className="text-gray-900">{user.phoneNumber}</p>
        </div>
      </div>
    </div>
  );
}
