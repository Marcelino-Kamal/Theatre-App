import { useState, useRef, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import logo from "../../assets/logo.png";
import { UserCircleIcon } from "@heroicons/react/24/outline";
import { LogOut } from "../../API/Auth";

export default function DashboardNav() {
  const navigate = useNavigate();
  const [openDropdown, setOpenDropdown] = useState(false);
  const [menuOpen, setMenuOpen] = useState(false);
  const dropdownRef = useRef(null);

  const handleLogout = async () => {
    try {
      await LogOut();
      navigate("/");
    } catch (error) {
      console.error(error.message);
      alert("Logout failed!");
    }
  };

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setOpenDropdown(false);
      }
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

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
          <h2 className="text-lg font-bold">Admin Menu</h2>
          <button
            onClick={() => setMenuOpen(false)}
            className="text-gray-600 hover:text-[#DA6868]"
          >
            ✕
          </button>
        </div>

        <nav className="flex flex-col p-4 space-y-4">
          <Link to="#" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>Contact Us</Link>
          <Link to="#" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>Location</Link>
          <Link to="/adminprofile" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>Profile</Link>
          <Link to="/manager" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>Manager</Link>
          <button onClick={handleLogout} className="text-red-600 hover:text-red-800 text-left">Logout</button>
        </nav>
      </div>

      <nav className="w-full px-4 py-3 bg-white shadow-md border-b border-gray-100 fixed top-0 left-0 z-50 flex-wrap">
        <div className="max-w-7xl mx-auto flex items-center justify-between relative">
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

          {/* Left: Contact Us & Location (Desktop Only) */}
          <div className="hidden md:flex items-center gap-6 flex-1">
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

          {/* Center: Logo */}
          <div className="absolute left-1/2 transform -translate-x-1/2">
            <Link to="/admin">
              <img src={logo} alt="Logo" className="h-20 w-auto" />
            </Link>
          </div>

          {/* Right: Profile (Desktop Only) */}
          <div className="hidden md:flex items-center gap-6 justify-end flex-1">
            <div className="relative" ref={dropdownRef}>
              <button
                onClick={() => setOpenDropdown((prev) => !prev)}
                className="flex items-center gap-2 focus:outline-none rounded-2xl"
              >
                <UserCircleIcon className="w-10 h-10 text-gray-600 hover:text-[#DA6868]" />
              </button>

              <div
                className={`absolute right-0 mt-2 w-40 bg-white border border-gray-200 rounded-lg shadow-lg z-50 transition-all duration-200 origin-top transform ${
                  openDropdown
                    ? "scale-100 opacity-100"
                    : "scale-95 opacity-0 pointer-events-none"
                }`}
              >
                <Link
                  to="/adminprofile"
                  className="block px-4 py-2 text-gray-700 hover:bg-gray-100"
                >
                  Profile
                </Link>
                <Link
                  to="/manager"
                  className="block px-4 py-2 text-gray-700 hover:bg-gray-100"
                >
                  Manager
                </Link>
                <button
                  onClick={handleLogout}
                  className="w-full text-left block px-4 py-2 text-red-600 hover:bg-red-100"
                >
                  Logout
                </button>
              </div>
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}
