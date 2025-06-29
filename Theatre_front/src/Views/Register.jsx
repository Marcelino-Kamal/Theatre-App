import logo from "../assets/logo.jpg";
import { Link } from "react-router-dom";

export default function Register() {
  return (
    <div className="w-full min-h-screen flex justify-center items-center bg-gray-100">
      <div className="flex flex-col w-[90%] sm:w-[60%] md:w-[40%] lg:w-[30%] bg-white rounded-2xl items-center p-6 shadow-lg">
        <img src={logo} alt="logo" className="w-[30%] h-auto mt-4 mb-4 " />

        <span className="text-lg font-semibold mb-4">Create your Account</span>

        <form method="POST" className="flex flex-col gap-4 w-full items-center">
          <input
            name="Name"
            placeholder="Username..."
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <input
            name="PhoneNumber"
            placeholder="Phone Number..."
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <input
            name="Password"
            type="password"
            placeholder="Password..."
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <input
            name="Confirm"
            type="password"
            placeholder="Confirm Password..."
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"
          />

          <button
            type="submit"
            className="mt-2  bg-[#D4A156] text-white rounded-xl py-2 hover:bg-blue-600 transition w-[50%]"
          >
            Sign Up
          </button>
        </form>
        <span>
          Already have and Account?
          <Link to="/login" className="underline">
            Sign In
          </Link>
        </span>
      </div>
    </div>
  );
}
