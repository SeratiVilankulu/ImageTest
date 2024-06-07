import { Route } from "react-router-dom";

import LoginPage from "./Pages/Login/LoginPage";
import RegisterPage from "./Pages/Register/RegisterPage";
import HomePage from "./Pages/HomePage";
import GoogleSignin from "./Pages/SocialSignin/GoogleSignin";
import GoogleSignin from "./Pages/SocialSignin/FacebookSignin";

function App() {
  return (
    <div>
      <Route path="/">
        <LoginPage />
      </Route>
      <Route path="/register">
        <RegisterPage />
      </Route>
      <Route path="/home">
        <HomePage />
      </Route>
      <Route path="/google-signin">
        <GoogleSignin />
      </Route>
      <Route path="/facebook-signin">
        <GoogleSignin />
      </Route>
    </div>
  );
}

export default App;
