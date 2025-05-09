let time = 25 * 60;
let timer;
let running = false;
let sessions = 0; 

let goal = 0;
let setsRemaining = 0;

function setGoal() {
    goal = parseInt(document.getElementById("setCount").value);
    setsRemaining = goal;
    document.getElementById("setsRemaining").textContent = `Sets remaining: ${setsRemaining}`;
}

function updateDisplay() {
    const minutes = Math.floor(time / 60);
    const seconds = time % 60;
    document.getElementById('timer').textContent = 
        `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;;
}

function startTimer() {
    if (!running && setsRemaining > 0) {
        running = true;
        timer = setInterval(() => {
            if (time > 0) {
                time--;
                updateDisplay();
            } else {
                clearInterval(timer);
                running = false;
                alert("🎉 Time's up! Take a break.");
                sessions++;
                setsRemaining--;
                document.getElementById('sessionCount').textContent = sessions;
                document.getElementById("setsRemaining").textContent = `Sets remaining: ${setsRemaining}`;
                if (setsRemaining > 0) {
                    time = 5 * 60; // break
                    updateDisplay();
                } else {
                    alert("💖 You've completed all your sets. Time to rest!");
                    time = 25 * 60;
                    updateDisplay();
                }
            }
        }, 1000);
    }
}

function stopTimer() {
    clearInterval(timer);
    running = false;
}

function resetTimer() {
    clearInterval(timer);
    running = false;
    time = 25 * 60;
    updateDisplay();
    sessions = 0;
    document.getElementById('sessionCount').textContent = sessions;
    setsRemaining = goal;
    document.getElementById("setsRemaining").textContent = `Sets remaining: ${setsRemaining}`;
}

updateDisplay();

const quotes = [
    "✨ Breathe in peace, breathe out doubt.",
    "🌿 Growth is silent. Keep going.",
    "☁️ You're allowed to start over. As many times as you need.",
    "🍵 Rest is productive too.",
    "📖 Romanticize your focus. Make it beautiful.",
    "🌸 One task at a time. No rush.",
    "🕯️ Light your mind like a candle—soft but bright.",
    "🌻 Even sunflowers turn slowly. You're doing fine."
];

function changeQuote() {
    const randomIndex = Math.floor(Math.random() * quotes.length);
    document.getElementById('quoteBox').textContent = quotes[randomIndex];
}

// Change quote every 5 minutes (300000 ms)
setInterval(changeQuote, 300000);

// Initial quote
changeQuote();