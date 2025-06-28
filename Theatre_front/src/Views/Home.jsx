import { Link } from "react-router-dom";


export default function Home() {
  return (
    // Wrapper Div
    <div className="w-full flex-col flex-wrap">
        <Link to="/login" className="text-lg underline text-blue-600">
          Go to Login
        </Link>
      </div>
  
  );
}

