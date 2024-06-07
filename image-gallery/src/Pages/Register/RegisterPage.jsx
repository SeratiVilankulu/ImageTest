import React from "react";
import { Link } from "react-router-dom";
import "./RegisterPage.css";

const RegisterPage = () => {
  return (
    <div className="register">
      <h1>Register Profile</h1>
      <p className="welcome">Welcom to the registration page. Please enter your details below.</p>
      <form action="">
        <div className="register-form">
          <p>Full Name</p>
          <input type="text" placeholder="Enter Name" required />
        </div>
        <div className="register-form">
          <p>Email Adress</p>
          <input type="text" placeholder="Enter Email" required />
        </div>
        <div className="register-form">
          <p>Password</p>
          <input type="text" placeholder="Enter Password" required />
        </div>
        <div className="register-form">
          <p>Confirm Password</p>
          <input type="text" placeholder="Enter Password" required />
        </div>
      </form>
      <button type="submit" className="register-btn">
        Register
      </button>

      <div className="separator">
        <p>or</p>
      </div>

      <button type="submit" className="option">
        Sign in with Google
      </button>

      <button type="submit" className="option">
        Sign in with Facebook
      </button>
    </div>
  );
};

export default RegisterPage;
