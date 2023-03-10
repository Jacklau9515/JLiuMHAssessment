import "./App.css";
import { Calculator } from "./Calculator";

function App() {
  return (
    <div className="App container">
      <h3
        className="d-flex justify-content-center m-3"
        style={{ color: "green" }}
      >
        LVR CALCULATOR
      </h3>
      <Calculator />
    </div>
  );
}

export default App;
