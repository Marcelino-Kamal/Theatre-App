import { Link } from "react-router-dom";
import MenuBar from "../components/MenuBar";

export default function Home() {
  return (
    // Wrapper Div
    <div className="w-full max-h-full flex-col flex-wrap">
      <MenuBar></MenuBar>
      {/* 2nd section on Home */}
      <div className="bg-[#D2B48C] w-full h-fit px-[15%] py-[5%] flex flex-col items-center ">
        <h1 className="font-bold text-[64px] tracking-tight leading-tight ">Welcome to Saint Mary <br></br>and Ava Bishop Church</h1>
        <span className="text-[30px] mt-[5%]">Looking to rent customs/props from our theatre?</span>
        <Link to="/login" className="text-white bg-[#DA6868] rounded-2xl h-10 px-4 flex items-center justify-center font-medium hover:bg-[#c55050] transition md:w-[20%] mt-[2.5%]">
        <button >Book Now</button>
        </Link>
      </div>
    </div>
  );
}
