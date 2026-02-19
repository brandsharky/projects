
//#region Hamburger Menu
const hamburger = document.getElementById("hamburger");
const navLinks = document.getElementById("navLinks");

hamburger.addEventListener("click", () => {
  navLinks.classList.toggle("active");
  hamburger.textContent = navLinks.classList.contains("active") ? "✖" : "☰";
});
//#endregion



//#region Form Review
const params = new URLSearchParams(window.location.search);

let score = 0;
let resultsHTML = "";

// QUESTION 1
if (params.get("q1") === "b") {
  score++;
  resultsHTML += "<p>Question 1: ✅ Correct</p>";
} else {
  resultsHTML += "<p>Question 1: ❌ Incorrect</p>";
}

// QUESTION 2
let q2 = params.get("q2");

if (q2 && q2.toLowerCase().trim() === "whale shark") {
  score++;
  resultsHTML += "<p>Question 2: ✅ Correct</p>";
} else {
  resultsHTML += "<p>Question 2: ❌ Incorrect</p>";
}

// QUESTION 3
if (params.get("q3") === "filter") {
  score++;
  resultsHTML += "<p>Question 3: ✅ Correct</p>";
} else {
  resultsHTML += "<p>Question 3: ❌ Incorrect</p>";
}

// QUESTION 4
let q4 = params.getAll("q4");

if (q4.includes("electroreception") && q4.length === 1) {
  score++;
  resultsHTML += "<p>Question 4: ✅ Correct</p>";
} else {
  resultsHTML += "<p>Question 4: ❌ Incorrect</p>";
}

// QUESTION 5
if (params.get("q5") === "apex") {
  score++;
  resultsHTML += "<p>Question 5: ✅ Correct</p>";
} else {
  resultsHTML += "<p>Question 5: ❌ Incorrect</p>";
}

resultsHTML = "<h3>Score: " + score + "/5</h3>" + resultsHTML;
document.getElementById("results").innerHTML = resultsHTML;
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


