import React, { useEffect, useRef, useState } from "react";
import { getAllUsers, UpdateUserStatus } from "../../../API/user";
import $ from "jquery";
import "datatables.net";

export default function UserTable() {
  const tableRef = useRef();
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [modalImage, setModalImage] = useState(null);
  const dataTable = useRef(null);

  useEffect(() => {
    const loadusers = async () => {
      try {
        const data = await getAllUsers();
        setUsers(
          data.map((user) => ({
            ...user,
            isApproved: !!user.isApproved,
          }))
        );
      } catch (error) {
        console.error("Error loading Users:", error.message);
      } finally {
        setLoading(false);
      }
    };

    loadusers();
  }, []);

  const handleCheckboxChange = (id, field) => {
    setUsers((prev) =>
      prev.map((user) =>
        user.id === id ? { ...user, [field]: !user[field] } : user
      )
    );
  };
  const handleSave = async (user) => {
    try {
      const payload = {
        Id: user.id,
        isActive: user.isApproved,
      };

      await UpdateUserStatus(payload);

      alert("User updated!");
    } catch (err) {
      console.error("Failed to update User", err.message);
      alert("Failed to update order.");
    }
  };
  useEffect(() => {
    if (!loading && users.length > 0 && !dataTable.current) {
      dataTable.current = $(tableRef.current).DataTable({
        stateSave: true,
      });
    }
  }, [loading]);

  return (
    <div className="p-6 min-h-screen bg-[#D2B48C]">
      <h2 className="text-2xl font-bold mb-6 mt-14">All Users</h2>

      {loading ? (
        <p>Loading...</p>
      ) : (
        <div className="overflow-x-auto bg-white rounded-xl shadow-lg p-4">
          <table
            ref={tableRef}
            className="display w-full border border-gray-300 text-sm text-left"
          >
            <thead className="bg-gray-100">
              <tr>
                <th className="border px-4 py-2">Id</th>
                <th className="border px-4 py-2">Name</th>
                <th className="border px-4 py-2">Phone Number</th>
                <th className="border px-4 py-2">Role</th>
                <th className="border px-4 py-2">Status</th>
                <th className="border px-4 py-2">National Id </th>
                <th className="border px-4 py-2">Enable/Disable</th>
              </tr>
            </thead>
            <tbody>
              {users.map((user) => (
                <tr key={user.id} className="hover:bg-gray-50 transition">
                  <td className="border px-4 py-2">{user.id}</td>
                  <td className="border px-4 py-2">{user.name}</td>
                  <td className="border px-4 py-2">{user.phoneNumber}</td>
                  <td className="border px-4 py-2">{user.role}</td>
                  <td className="border px-4 py-2">
                    <input
                      type="checkbox"
                      checked={user.isApproved}
                      onChange={() =>
                        handleCheckboxChange(user.id, "isApproved")
                      }
                    />
                  </td>
                  <td className="border px-4 py-2">
                    <img
                      src={`${
                        import.meta.env.VITE_API_BASE_URL
                      }${user.nationalId.replace(/\\/g, "/")}`}
                      alt={user.name}
                      className="h-16 w-16 object-cover rounded cursor-pointer hover:scale-105 transition"
                      onClick={() =>
                        setModalImage(
                          `${
                            import.meta.env.VITE_API_BASE_URL
                          }${user.nationalId.replace(/\\/g, "/")}`
                        )
                      }
                    />
                  </td>
                  <td className="border px-4 py-2">
                    <button
                      onClick={() => handleSave(user)}
                      className="bg-[#D2B48C] text-white px-3 py-1 rounded hover:bg-[#DA6868]"
                      onChange={() =>
                        handleCheckboxChange(user.id, "isApproved")
                      }
                    >
                      Enable/Disable
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
      {modalImage && (
        <div className="fixed inset-0 bg-black bg-opacity-60 flex justify-center items-center z-50">
          <div className="bg-white p-4 rounded-lg max-w-[90%] max-h-[90%] relative">
            <button
              onClick={() => setModalImage(null)}
              className="absolute top-2 right-2 text-white bg-red-600 rounded-full w-8 h-8 text-center leading-8 hover:bg-red-700"
            >
              ×
            </button>
            <img
              src={modalImage}
              alt="National ID"
              className="max-w-full max-h-[80vh] rounded"
            />
          </div>
        </div>
      )}
    </div>
  );
}
