import { Link } from "react-router-dom";
import logo from "../assets/logo.jpg";

export default function MenuBar() {
  return (
    <nav className="w-full px-4 py-3 bg-white  shadow-md border-b border-gray-100 rounded-3xl">
      <div className="max-w-7xl mx-auto flex items-center justify-between flex-wrap ">
        {/* Left Side */}
        <div className="flex items-center gap-6">
          <Link
            to="#"
            className="text-white bg-[#DA6868] rounded-2xl h-10 px-4 flex items-center justify-center font-medium hover:bg-[#c55050] transition"
          >
            Contact Us
          </Link>

          <Link
            to="#"
            className="text-white bg-[#DA6868] rounded-2xl h-10 px-4 flex items-center justify-center font-medium hover:bg-[#c55050] transition"
          >
            Location
          </Link>
        </div>

        {/* Logo */}
        <div>
          <img src={logo} alt="Logo" className="h-30 w-auto" />
        </div>

        {/* Right Side */}
        <div className="flex items-center gap-6">
          <Link
            to="/login"
            className="text-white bg-[#DA6868] rounded-2xl h-10 px-4 flex items-center justify-center font-medium hover:bg-[#c55050] transition"
          >
            Sign In
          </Link>
          <Link
            to="/signup"
            className="text-white bg-[#DA6868] rounded-2xl h-10 px-4 flex items-center justify-center font-medium hover:bg-[#c55050] transition"
          >
            Sign Up
          </Link>
        </div>
      </div>
    </nav>
  );
}
