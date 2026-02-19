
//#region Hamburger Menu
const hamburger = document.getElementById("hamburger");
const navLinks = document.getElementById("navLinks");

hamburger.addEventListener("click", () => {
  navLinks.classList.toggle("active");
  hamburger.textContent = navLinks.classList.contains("active") ? "✖" : "☰";
});
//#endregion



//#region Generate Random Fact
const randomFacts = [
  "Sharks existed before trees.",
  "Some sharks glow in the dark.",
  "Sharks do not have bones — their skeletons are made of cartilage.",
  "A shark can detect a drop of blood from hundreds of meters away.",
  "There are over 500 species of sharks.",
  "The whale shark is the largest fish in the ocean.",
  "Some sharks must keep swimming to breathe.",
  "Shark skin feels like sandpaper."
];

const button = document.getElementById("generateBtn");
const factText = document.getElementById("fact");
const factCountText = document.getElementById("factCount");

let factCount = localStorage.getItem("factCount");

// If it doesn't exist yet, start at 0
if (factCount === null) {
  factCount = 0;
} else {
  factCount = Number(factCount);
}

// Show initial count
factCountText.textContent = `Facts Generated: ${factCount}`;

function generateFact() {
  factText.textContent = randomFacts[Math.floor(Math.random() * randomFacts.length)];

  factCount++;

  // Save to localStorage
  localStorage.setItem("factCount", factCount);

  // Update display
  factCountText.textContent = `Facts Generated: ${factCount}`;
}

button.addEventListener("click", generateFact);
//#endregion



//#region Footer

// Current Year
document.getElementById("currentYear").textContent = new Date().getFullYear();

// Last Modified
const modified = new Date(document.lastModified);
const options = { year: "numeric", month: "long", day: "numeric" };
document.getElementById("lastModified").textContent = modified.toLocaleDateString("en-US", options);

// Random Fact
const facts = ["Sharks don't have vocal chords. They express their emotions physically.", "Sharks have a sixth sense where they can feel the electrical impulses of other animals.", "The Whale Shark is the largest known fish in the sea.", "Hammerhead Sharks can see 360° degrees around them.", "The Whale Shark is like a whale.™", "A shark's entire skeleton is made of cartilage, not bone.", "Sharks have excellent eyesight.", "Sharks are older than dinosaurs."];
const fact = facts[Math.floor(Math.random() * facts.length)];
document.getElementById("footerFact").textContent = fact;
//#endregion


