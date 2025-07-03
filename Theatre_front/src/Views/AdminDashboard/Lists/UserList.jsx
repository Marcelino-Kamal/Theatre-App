import React, { useEffect, useRef, useState } from "react";
import { getAllUsers } from "../../../API/user";
import $ from "jquery";
import "datatables.net";

export default function ProductTable() {
  const tableRef = useRef();
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const dataTable = useRef(null);

  useEffect(() => {
    const loadusers = async () => {
      try {
        const data = await getAllUsers();
        setUsers(data);
      } catch (error) {
        console.error("Error loading Users:", error.message);
      } finally {
        setLoading(false);
      }
    };

    loadusers();
  }, []);

  useEffect(() => {
    if (!loading && users.length > 0) {
      dataTable.current = $(tableRef.current).DataTable();
    }

    return () => {
      if (dataTable.current) {
        dataTable.current.destroy();
        dataTable.current = null;
      }
    };
  }, [loading, users]);

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
              </tr>
            </thead>
            <tbody>
              {users.map((user) => (
                <tr key={user.id} className="hover:bg-gray-50 transition">
                  <td className="border px-4 py-2">{user.id}</td>
                  <td className="border px-4 py-2">{user.name}</td>
                  <td className="border px-4 py-2">{user.phoneNumber}</td>
                  <td className="border px-4 py-2">{user.role}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}
