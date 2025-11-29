# Installing Tailwind CSS v4 in Blazor WebAssembly

## Prerequisites
- Node.js installed on your system
- Blazor WebAssembly project

## Step 1: Create package.json
Create a `package.json` file in your project root:

```json
{
  "name": "blazor-tailwind",
  "version": "1.0.0",
  "scripts": {
    "build-css": "tailwindcss -i ./Styles/input.css -o ./wwwroot/css/tailwind.css",
    "watch-css": "tailwindcss -i ./Styles/input.css -o ./wwwroot/css/tailwind.css --watch"
  },
  "devDependencies": {
    "@tailwindcss/cli": "^4.0.0-alpha.30"
  }
}
```

## Step 2: Install Dependencies
Run in your project directory:
```bash
npm install
```

## Step 3: Create Styles Directory and Input CSS
1. Create a `Styles` folder in your project root
2. Create `Styles/input.css` with:

```css
@import "tailwindcss";
```

## Step 4: Create Tailwind Configuration
Create `tailwind.config.js` in your project root:

```javascript
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./**/*.{razor,html,cshtml}",
    "./Pages/**/*.razor",
    "./Layout/**/*.razor",
    "./wwwroot/index.html"
  ]
}
```

## Step 5: Update index.html
In `wwwroot/index.html`, add the Tailwind CSS link:

```html
<link rel="stylesheet" href="css/tailwind.css" />
```

Replace or add this before your existing CSS links.

## Step 6: Build Tailwind CSS
Run one of these commands:

**One-time build:**
```bash
npm run build-css
```

**Watch mode (rebuilds on changes):**
```bash
npm run watch-css
```

## Step 7: Test Installation
Add Tailwind classes to any Razor component:

```html
<div class="bg-blue-500 text-white p-4 rounded-lg">
    <h1 class="text-2xl font-bold">Hello Tailwind!</h1>
</div>
```

## Development Workflow
1. Run `npm run watch-css` in a terminal to watch for changes
2. Edit your Razor components with Tailwind classes
3. CSS will automatically rebuild when you save files

## Build Process Integration
For production builds, add the CSS build step to your CI/CD pipeline:
```bash
npm run build-css
dotnet publish
```

## Troubleshooting
- Ensure Node.js is installed and accessible
- Check that the `wwwroot/css/tailwind.css` file is generated
- Verify Tailwind classes are being purged correctly by checking the output CSS size
- Make sure your Razor files are included in the `content` array in `tailwind.config.js`