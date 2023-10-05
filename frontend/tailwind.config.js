/** @type {import('tailwindcss').Config} */

import flowbite from "flowbite/plugin";
export default {
  plugins: [flowbite],
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
    "./index.html",
    "./node_modules/flowbite-react/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    colors: {
      "clr-bg1": `var(${"--color-bg-primary"})`,
      "clr-bg2": `var(${"--color-bg-secondary"})`,
      "clr-bg3": `var(${"--color-bg-tertiary"})`,
      "clr-text1": `var(${"--color-text-primary"})`,
      "clr-text2": `var(${"--color-text-secondary"})`,
      "clr-hover": `var(${"--color-text-hover"})`,
    },
    fontSize: {
      "fs-h1": "24px",
      "fs-h2": "18px",
      "fs-h3": "14px",
    },
    backgroundImage: {
      mainBg: "url('/background.webp')",
      pizza: "url('/pizza.jpg')",
    },
  },
};
