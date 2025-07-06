import { useState } from "react";
import { Link } from "react-router-dom";
import logo from "../assets/logo.png";

export default function MenuBar() {
  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <>
      {/* Overlay */}
      {menuOpen && (
        <div
          className="fixed inset-0 bg-black opacity-40 z-40"
          onClick={() => setMenuOpen(false)}
        ></div>
      )}

      {/* Sidebar Drawer */}
      <div
        className={`fixed top-0 left-0 h-full w-64 bg-white shadow-lg z-50 transform transition-transform duration-300 ease-in-out ${
          menuOpen ? "translate-x-0" : "-translate-x-full"
        }`}
      >
        <div className="p-4 border-b flex justify-between items-center">
          <h2 className="text-lg font-bold">Menu</h2>
          <button
            onClick={() => setMenuOpen(false)}
            className="text-gray-600 hover:text-[#DA6868]"
          >
            ✕
          </button>
        </div>
        <nav className="flex flex-col p-4 space-y-4">
          <Link
            to="#"
            className="text-gray-700 hover:text-[#DA6868]"
            onClick={() => setMenuOpen(false)}
          >
            Contact Us
          </Link>
          <Link
            to="#"
            className="text-gray-700 hover:text-[#DA6868]"
            onClick={() => setMenuOpen(false)}
          >
            Location
          </Link>
          <Link
            to="/login"
            className="text-[#DA6868] font-medium hover:underline"
            onClick={() => setMenuOpen(false)}
          >
            Sign In
          </Link>
          <Link
            to="/signup"
            className="text-[#DA6868] font-medium hover:underline"
            onClick={() => setMenuOpen(false)}
          >
            Sign Up
          </Link>
        </nav>
      </div>

      {/* Navbar */}
      <nav className="w-full px-4 py-3 bg-white shadow-md border-b border-gray-100 rounded-3xl">
        <div className="max-w-7xl mx-auto flex items-center justify-between flex-wrap">
          {/* Hamburger Icon (Mobile Only) */}
          <div className="md:hidden">
            <button
              onClick={() => setMenuOpen(true)}
              className="text-gray-600 hover:text-[#DA6868]"
            >
              <svg
                className="w-8 h-8"
                fill="none"
                stroke="currentColor"
                strokeWidth={2}
                viewBox="0 0 24 24"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  d="M4 6h16M4 12h16M4 18h16"
                />
              </svg>
            </button>
          </div>

          {/* Left Side (Desktop Only) */}
          <div className="hidden md:flex items-center gap-6">
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
            <img src={logo} alt="Logo" className="h-20 w-auto" />
          </div>

          {/* Right Side (Desktop Only) */}
          <div className="hidden md:flex items-center gap-6">
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
    </>
  );
}
