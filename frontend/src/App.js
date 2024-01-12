import React, { useState } from "react";
import './styles/App.css';
import ImageManager from "./components/ImageManager";
import ImageView from "./components/ImageView";

function App() {
  const [currentImage, setCurrentImage] = useState(null)
  
  return (
    <div className="App">
      <ImageManager currentImage={currentImage} setImage={(image) => setCurrentImage(image)}/>
      <ImageView image={currentImage}/>
    </div>
  );
}

export default App;
