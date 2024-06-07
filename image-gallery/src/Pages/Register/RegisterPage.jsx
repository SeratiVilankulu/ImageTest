import React from "react";
import { Link } from "react-router-dom";
import "./RegisterPage.css";

const RegisterPage = () => {
  return (
    <div className="register">
      <h1>Register Profile</h1>
      <p className="welcome">
        Welcom to the registration page. Please enter your details below.
      </p>
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

      <img
        src="/images/Image.jpg"
        alt="Work station"
        className="register-image"
      />

      <button type="submit" className="option">
        <Link to="/google-signin" className="signin-btn">
          Sign in with Google
        </Link>
      </button>

      <button type="submit" className="option">
        <Link to="/facebook-signin" className="signin-btn">
          Sign in with Facebook
        </Link>
      </button>
    </div>
  );
};

export default RegisterPage;
