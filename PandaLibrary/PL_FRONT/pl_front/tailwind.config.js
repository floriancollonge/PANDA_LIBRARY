const colors = require('tailwindcss/colors')

module.exports = {
  content: ["./public/**/*.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
  theme: {
    extend: {
      fontFamily: {
        poppins: ["POPPINS", "sans-serif"],
        poppinsBold: ["POPPINS_BOLD", "sans-serif"],
      },
      colors: {
        'green': {
          900: '#72A852',
          700: '#4CCA6D',
          500: '#81D891',
          300: '#AFE6B4',
          100: '#D7F3DB'
        },
        'gray': '#F2F2F2',
      },
      minWidth: {
        '100': '100px',
      },
      minHeight: {
        '150': '150px',
        '300': '300px',
      },
      spacing: {
        '50': '50px',
        '500': '500px',
      }
    }
  },
  plugins: [],
};
