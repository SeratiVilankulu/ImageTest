import React, { useState, useEffect } from "react";
import "./UploadPage.css";

const defaultImageSrc = "/images/employee.jpg"; //Image Preview

const initialFieldValues = {
  EmployeeID: 0,
  EmployeeName: "",
  Occupation: "",
  ImageName: "",
  ImageSrc: defaultImageSrc,
  ImageFile: null,
};

function UploadPage() {
  const [values, setValues] = useState(initialFieldValues);
  const [errors, setErrors] = useState({});

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setValues({
      ...values,
      [name]: value,
    });
  };

  //Checks if image has been uploaded
  const showPreview = (e) => {
    if (e.target.files && e.target.files[0]) {
      let imageFile = e.target.files[0];
      //show selected image prview
      const reader = new FileReader();
      reader.onload = (x) => {
        setValues({
          ...values,
          imageFile,
          ImageSrc: x.target.result,
        });
      };
      reader.readAsDataURL(imageFile);
    } else {
      setValues({
        ...values,
        imageFile: null,
        ImageSrc: defaultImageSrc,
      });
    }
  };

  //Validations for name and occupation
  const validate = () => {
    let temp = {};
    temp.EmployeeName = values.EmployeeName == "" ? false : true;
    temp.imageSrc = values.imageSrc == defaultImageSrc ? false : true;
    setErrors(temp);
    return Object.values(temp).every((x) => x == true);
  };

  const handleFormSubmit = (e) => {
    //prevent the default behavior of form submit event
    e.preventDefault();
    if (validate()) {
    }
  };
  const applyErrorClass = (field) =>
    field in errors && errors[field] == false ? " invalid-field" : "";

  return (
    <div className="heading">
      <h1>Employee Register</h1>
      <div className="upload-container">
        <div className="employee-form">
          <p>An Employee</p>
          <div className="form">
            <form autoComplete="off" noValidate onSubmit={handleFormSubmit}>
              <div className="card">
                <img
                  src={values.ImageSrc}
                  className={"image" + applyErrorClass("imageSrc")}
                />{" "}
                {/*Shows corresponding image on image preview*/}
                <div className="card-body">
                  <div className="form-group">
                    <input
                      type="file"
                      accept="image/*"
                      className="imageFile"
                      onChange={showPreview}
                    />
                  </div>
                  <div className="form-group">
                    {/*Input for employee name*/}
                    <input
                      type="text"
                      className={
                        "form-control" + applyErrorClass("EmployeeName")
                      }
                      placeholder="Employee Name"
                      name="EmployeeName"
                      values={values.EmployeeName}
                      onChange={handleInputChange}
                    />
                  </div>
                  <div className="form-group">
                    {/*Input for employee occupation*/}
                    <input
                      type="text"
                      className="form-control"
                      placeholder="Occupation"
                      name="Occupation"
                      values={values.Occupation}
                      onChange={handleInputChange}
                    />
                  </div>
                  <div className="btn">
                    <input type="submit" className="Submit-btn" />
                  </div>
                </div>
              </div>
            </form>
          </div>
        </div>
        <div className="employeelist">
          <div>List of employees</div>
        </div>
      </div>
    </div>
  );
}
export default UploadPage;
