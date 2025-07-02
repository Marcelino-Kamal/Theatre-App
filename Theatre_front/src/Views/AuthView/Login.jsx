import logo from "../../assets/logo.png";
import { useState } from "react";
import { Link, Navigate } from "react-router-dom";
import { signIn } from "../../API/Auth";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const [formData, setFormData] = useState({
    PhoneNumber: "",
    Password: "",
  });
  const navigate = useNavigate();
  const handleChange = (e) => {
    setFormData((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const res = await signIn(formData);
      alert(res.message);
      navigate("/dashboard");
    } catch (err) {
      alert(err);
    }
  };
  return (
    <div className="w-full min-h-screen flex justify-center items-center bg-gray-100">
      <div className="flex flex-col w-[90%] sm:w-[60%] md:w-[40%] lg:w-[30%] bg-white rounded-2xl items-center p-6 shadow-lg">
        <img src={logo} alt="logo" className="w-[30%] h-auto mt-4 mb-4 " />

        <span className="text-lg font-bold mb-4">Login to your Account</span>

        <form
          method="POST"
          className="flex flex-col gap-4 w-full items-center"
          onSubmit={handleSubmit}
        >
          <input
            name="PhoneNumber"
            placeholder="Phone Number..."
            onChange={handleChange}
            value={formData.PhoneNumber}
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <input
            name="Password"
            type="password"
            placeholder="Password..."
            onChange={handleChange}
            value={formData.Password}
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <button
            type="submit"
            className="mt-2  bg-[#D4A156] text-white rounded-xl py-2 hover:bg-blue-600 transition w-[50%]"
          >
            Sign In
          </button>
        </form>
        <span>
          Don't have and Account?
          <Link to="/signup" className="underline text-blue-500">
            Sign up
          </Link>
        </span>
      </div>
    </div>
  );
}
