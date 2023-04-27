import React, { useEffect, useState } from "react";
import AdminService from "../services/AdminService";
import { useParams } from "react-router-dom";

interface admin {
  id: string;
  firstName: string;
  lastName: string;
  birthDate: Date;
  nationalCode: string;
}

const AdminPage = () => {
  const params = useParams();
  const [user, setUser] = useState<admin>();
  useEffect(() => {
    const { GetAdminById } = new AdminService();
    if (params.id) GetAdminById(params, setUser);
  }, []);
  return (
    <>
      <div>User page</div>
    </>
  );
};

export default AdminPage;
