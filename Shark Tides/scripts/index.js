
//#region Hamburger Menu
const hamburger = document.getElementById("hamburger");
const navLinks = document.getElementById("navLinks");

hamburger.addEventListener("click", () => {
  navLinks.classList.toggle("active");
  hamburger.textContent = navLinks.classList.contains("active") ? "✖" : "☰";
});
//#endregion



//#region Footer

// Current Year
document.getElementById("currentYear").textContent = new Date().getFullYear();

// Last Modified
const modified = new Date(document.lastModified);
const options = { year: "numeric", month: "long", day: "numeric" };
document.getElementById("lastModified").textContent = modified.toLocaleDateString("en-US", options);

// Random Fact
const facts = [
  "Sharks don't have vocal chords. They express their emotions physically.",
  "Sharks have a sixth sense where they can feel the electrical impulses of other animals.",
  "The Whale Shark is the largest known fish in the sea.",
  "Hammerhead Sharks can see 360° degrees around them.",
  "The Whale Shark is like a whale.™",
  "A shark's entire skeleton is made of cartilage, not bone.",
  "Sharks have excellent eyesight.",
  "Sharks are older than dinosaurs."
];
const fact = facts[Math.floor(Math.random() * facts.length)];
document.getElementById("footerFact").textContent = fact;
//#endregion


