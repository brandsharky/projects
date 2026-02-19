
//#region Hamburger Menu
const hamburger = document.getElementById("hamburger");
const navLinks = document.getElementById("navLinks");

hamburger.addEventListener("click", () => {
  navLinks.classList.toggle("active");
  hamburger.textContent = navLinks.classList.contains("active") ? "✖" : "☰";
});
//#endregion



//#region Sources
const sources = [
  {
    title: "50 Shocking Facts about Sharks",
    organization: "Best Life",
    linkUrl: "https://bestlifeonline.com/sharks-facts/",
  },
  {
    title: "12 Shark Facts That May Suprise You",
    organization: "NOAA",
    linkUrl: "https://www.fisheries.noaa.gov/feature-story/12-shark-facts-may-surprise-you",
  },
  {
    title: "Sharks",
    organization: "World Wildlife Fund",
    linkUrl: "https://www.worldwildlife.org/species/shark/",
  },
  {
    title: "Shark Species",
    organization: "Shark Research Institue",
    linkUrl: "https://www.sharks.org/species",
  },
  {
    title: "Sharks",
    organization: "Monteray Bay Aquarium",
    linkUrl: "https://www.montereybayaquarium.org/animals/animals-a-to-z/sharks",
  },
  {
    title: "Sharks",
    organization: "Zoobooks",
    linkUrl: "https://a.co/d/096rwHhd",
  },
  {
    title: "The Coolest Creature That Is A Shark",
    organization: "Brandon Arroyo",
    linkUrl: "https://brandsharky.github.io/coolest-creature/",
  },
  {
    title: "The Coolest Creature That Is A Shark 2.0",
    organization: "Brandon Arroyo",
    linkUrl: "https://brandsharky.github.io/CISIWEB-74/Coolest%20Creature/",
  },
  {
    title: "All Images",
    organization: "Unsplash",
    linkUrl: "https://unsplash.com/",
  }
];

const gallery = document.getElementById("sources");

gallery.innerHTML = "";

function displaySources(sourceList){
  sourceList.forEach(source => {
    const card = document.createElement("div");
    card.classList.add("source");

    card.innerHTML = `
    <h3>${source.title}</h3>
    <p>${source.organization}</p>
    <a href="${source.linkUrl}" target="_blank">Visit Source</a>
  `;

    gallery.appendChild(card);
  });
}

displaySources(sources);
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


