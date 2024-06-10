import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";

import LoginPage from "./Pages/Login/LoginPage.jsx";
import RegisterPage from "./Pages/Register/RegisterPage.jsx";
import "./index.css";
import GoogleSignin from "./Pages/SocialSignin/GoogleSignin.jsx";
import FacebookSignin from "./Pages/SocialSignin/FacebookSignin.jsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <LoginPage />,
  },
  {
    path: "/register",
    element: <RegisterPage />,
  },
  {
    path: "/google-signin",
    element: <GoogleSignin />,
  },
  {
    path: "/facebook-signin",
    element: <FacebookSignin />,
  },

  //add more routes
]);

export default function main() {
  return (
    <div>
      <RouterProvider router={router} />
    </div>
  );
}

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
