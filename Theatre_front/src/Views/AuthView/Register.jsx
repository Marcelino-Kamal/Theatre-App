import { useState } from "react";
import logo from "../../assets/logo.png";
import { Link } from "react-router-dom";
import { signUpUser } from "../../API/Auth";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const [formData, setFormData] = useState({
    Name: "",
    PhoneNumber: "",
    Password: "",
    Confirm: "",
    NationalId:null

  });
  const navigate = useNavigate();

  const handleChange = (e) => {
  const { name, value, type, checked, files } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: type === "checkbox" ? checked : type === "file" ? files[0] : value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (formData.Password !== formData.Confirm) {
      alert("Passwords do not match");
      return;
    }

    try {
      const res = await signUpUser(formData);
      navigate("/login");
      alert(res.message);
    } catch (err) {
      alert(err);
    }
  };

  return (
    <div className="w-full min-h-screen flex justify-center items-center bg-gray-100">
      <div className="flex flex-col w-[90%] sm:w-[60%] md:w-[40%] lg:w-[30%] bg-white rounded-2xl items-center p-6 shadow-lg">
        <img src={logo} alt="logo" className="w-[30%] h-auto mt-4 mb-4 " />

        <span className="text-lg font-semibold mb-4">Create your Account</span>

        <form
          method="POST"
          onSubmit={handleSubmit}
          className="flex flex-col gap-4 w-full items-center"
        >
          <input
            name="Name"
            placeholder="Username..."
            value={formData.Name}
            onChange={handleChange}
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400 w-full"
          />
          <input
            name="PhoneNumber"
            placeholder="Phone Number..."
            value={formData.PhoneNumber}
            onChange={handleChange}
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400 w-full"
          />
          <input
            name="Password"
            type="password"
            placeholder="Password..."
            value={formData.Password}
            onChange={handleChange}
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400 w-full"
          />
          <input
            name="Confirm"
            type="password"
            placeholder="Confirm Password..."
            value={formData.Confirm}
            onChange={handleChange}
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-400 w-full"
          />
          <div className="md:col-span-2 w-full flex flex-col justify-center items-center">
            <label className="block mb-1 font-medium ">National Id </label>
            <input
              type="file"
              name="NationalId"
              onChange={handleChange}
              accept="image/*"
              className="w-full border border-gray-300 rounded-xl p-2"
              required
            />
          </div>

          <button
            type="submit"
            className="mt-2 bg-[#D4A156] text-white rounded-xl py-2 hover:bg-blue-600 transition w-[50%]"
          >
            Sign Up
          </button>
        </form>
        <span className="mt-4">
          Already have an account?{" "}
          <Link to="/login" className="underline text-blue-500">
            Sign In
          </Link>
        </span>
      </div>
    </div>
  );
}
