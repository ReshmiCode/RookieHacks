import React from "react";
import "./App.css";
import { Button } from "@material-ui/core";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Recycle Bun... Recycle Or Be Recycled</h1>
        <p>
          When dealing with your used items, knowing what’s recyclable and what isn’t is often a challenge. 
          Different materials might need to be sorted and recycled separately. 
          Trash placed in recycling bins decreases the efficiency of recycling centers, 
          damages equipment, and can contaminate actual recyclables. 
          Recycle Bun is a fun game that encourages recycling and reminds players of proper recycling procedures.
        </p>
        <iframe
          width="840"
          height="473"
          src="https://www.youtube.com/embed/FnMZTbqBy2s"
          frameborder="0"
          allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
          allowfullscreen
          title="Demo Video"
        ></iframe>
        <p>
          Recycle Bun is a “bullet dodge” or “barrage” game, 
          where the player controls a responsible bunny who is trying to properly recycle different items. 
          Ingame, items approach the player character, some recyclable and some not. 
          The player must avoid the trash and pick up the recyclable items. 
          The player must also switch between the appropriate bins (paper, plastic, or glass) when picking up recyclables.
        </p>
        <iframe
          width="1000"
          height="700"
          src="https://recycle-bun-game.web.app"
          frameborder="0"
          allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
          allowfullscreen
          title="Demo Video"
        ></iframe>
        <div className="button-area">
          <Button className="button" variant="contained">
            <a href="https://storage.googleapis.com/recycle-bun-macos/RecycleBunMacOS.zip" target="_blank" rel="noopener noreferrer" download>
              Download for MacOS
            </a>
          </Button>
        </div>
        <div className="button-area">
          <Button className="button" variant="contained">
            <a href="https://storage.googleapis.com/recycle-bun-macos/RecycleBunWindows.zip" target="_blank" rel="noopener noreferrer" download>
              Download for Windows
            </a>
          </Button>
        </div>
        <div className="button-area">
          <Button className="button" variant="contained">
            <a href="https://connect.unity.com/mg/other/recycle-bun" target="_blank" rel="noopener noreferrer">
              Try It On Connect.Unity
            </a>
          </Button>
        </div>
        <div className="button-area">
          <Button className="button" variant="contained">
            <a href="https://devpost.com/software/recycle-bun" target="_blank" rel="noopener noreferrer">
              More Info
            </a>
          </Button>
        </div>
        <div className="button-area">
          <Button className="button" variant="contained">
            <a href="https://github.com/ReshmiCode/RookieHacks" target="_blank" rel="noopener noreferrer">
              Source Code
            </a>
          </Button>
        </div>
        <p>
          Made with 💖 by Megan Tran, Reshmi Ranjith, Saloni Shivdasani, and
          Vincent Vu
        </p>
        <div className="button-area">
          <Button className="button" variant="contained">
            <a href="mailto:hackathon.dream.team.utd@gmail.com" target="_blank" rel="noopener noreferrer">
              Contact the Developers
            </a>
          </Button>
        </div>
      </header>
    </div>
  );
}

export default App;