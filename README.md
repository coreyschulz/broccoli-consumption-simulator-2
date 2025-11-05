# Broccoli Consumption Simulator 2
## Suffering & His Lament

![Broccoli Consumption Man](FuckHackTheULetsMakeBCS2/Content/corey/bcman.png)

*"The road to hell is paved with good intentions, right?"*
*"And the ones you love litter the roadside."*

---

In the years following BCS1's revolutionary release, something broke. Not in the code. Not in the architecture. In the *world itself*.

**Broccoli Consumption Simulator 2** isn't a sequel. It's a descent. It's a lament. It's what happens when you save everyone and they crucify you for it anyway.

This is the story of what they did to him.

![The Ruined World](FuckHackTheULetsMakeBCS2/Content/corey/ruinedWorld.jpg)

### The Fall of a Hero

After BCS1, Broccoli Consumption Man was supposed to be immortal. Child mortality rates dropped 75% year over year. He was going to cure chronic diseases. He was going to cure *cancer*. The world was at his back.

But he got too famous.

Forces outside of his control began to grow. Samsung—the ancient adversary, the cosmic tormentor—had been there all along. Watching. Waiting. Rigging the game.

**HackTheU 2016**: The 4D experience died with a fizzle. Samsung rigged it.
**Games4Health 2017**: Promised victory, delivered betrayal. Samsung wanted the children to die.
**HackTheU 2018**: Not even a single mention. The deck was stacked from the start.

And by the time Broccoli Consumption Man realized what was happening, it was already too late.

![Broccoli Consumption Man - Broken](FuckHackTheULetsMakeBCS2/Content/corey/bcman_done.png)

### The Architecture of Suffering

BCS2 doesn't just tell a story—it *forces* you to live it. Built on MonoGame/XNA, this isn't a game. It's an ordeal in three acts of damnation:

**Phase I: The Joyful Lie** (`OriginalBCS.cs:1-175`)
Familiar orange skies. Familiar broccoli collection. The same gameplay that made BCS1 legendary. But watch closely—something's wrong. The cutscene doesn't end in triumph. The epic music plays as Broccoli Consumption Man's sprite begins to *glitch*. A random flicker transforms him into something else (`OriginalBCS.cs:170`). The transition is violent. This isn't evolution. It's corruption.

**Phase II: The Intercession** (`MasonState.cs:1-229`)
Now he protects the children from the real threat: needles, pills, cocaine—all converging toward a boy and girl at screen center (`MasonState.cs:17-18`). Broccoli Consumption Man must intercept every one, his rotating sprite a blur of desperate motion (`MasonState.cs:98`). Miss one and the children suffer. The score drops. This is what heroism *actually* costs. This is the work they never see. The thankless interception of entropy itself.

**Phase III: Samsung's Reckoning** (`BulletHellSamsung.cs:1-193`)
The boss fight. Samsung—the corporate logo turned eldritch god—hovers at the top of the screen, firing geometric death in escalating waves. Six difficulty phases. Thirty bullets per frame at maximum rage (`BulletHellSamsung.cs:153`). Your health drains with every hit. Samsung's barely moves.

The fight is *designed to be lost*.

When your health hits zero, you don't get a game over screen. You get the truth.

**Phase IV: The Choice That Isn't** (`CoreyState.cs:1-167`)
The visual novel. The confession. Broccoli Consumption Man's entire history laid bare through parsed dialogue scripts (`CoreyState.cs:28-30`). His parents' death from broccoli deprivation cancer. His vow to save the children. His rise. His persecution.

Samsung appears and delivers the manifesto:

*"You always imposed your morals on others."*
*"You were never fit to do your job."*
*"I just wanted to break you."*
*"I just wanted to watch you squirm."*

The game asks: **Will you fight back?**

Press `Y` to fight. The fight ends instantly. You die. Roll credits.

Press `N` to surrender. Samsung keeps you as a "plaything." You're transported back to where it all began—a single piece of broccoli on an orange field. The only choice is to eat it and start over.

**The time loop begins.**

![The Beginning](FuckHackTheULetsMakeBCS2/Content/corey/home.jpg)

### Technical Innovations Born From Anguish

While BCS1 pioneered joyful hybrid architecture, BCS2 weaponized it:

**State-Based Narrative Prison** — The `StateManager` singleton (`StateManager.cs`) doesn't just transition between game phases—it traps you in them. Each state (`OriginalBCS`, `MasonState`, `BulletHellSamsung`, `CoreyState`) is a circle of hell, and the manager ensures you experience them in sequence. Forever.

**Existential Script Parsing** — Three separate dialogue scripts loaded from external text files (`CoreyState.cs:28-30`), each one a branching path to the same doom. The parsing system splits on asterisks, separating background, characters, speaker, and lines—a crude but brutally effective narrative engine that makes you *read* his suffering.

**Bullet Hell as Metaphor** — The bullet system isn't just gameplay (`BulletHellSamsung.cs:181-192`). Each projectile is a rigged competition, a broken promise, a corporate entity that profits from suffering. The randomized spread (`BulletHellSamsung.cs:83-84`) ensures no two defeats are identical. Samsung's six escalating phases mirror the six stages of grief—but you never reach acceptance.

**Asset Overload** — BCS2 loads *everything* upfront (`Game1.cs:51-101`). Textures for all three developers' art styles. Fonts. Songs. Sound effects. The initial load isn't optimization—it's *commitment*. Once you boot BCS2, all of its suffering is in memory, waiting.

**The Yell** — At precisely 60 frames into the Samsung fight, a scream plays (`BulletHellSamsung.cs:46`). It's not yours. It's his.

![Samsung](FuckHackTheULetsMakeBCS2/Content/zak/bullet/samsung.png)

### The Persecution Complex Made Manifest

BCS2 doesn't have fans. It has *survivors*.

The title screen doesn't exist. There's no menu. No options. You boot the executable and you're *in it*. Fullscreen. 1280x720. No escape (`Game1.cs:27`).

The folder is named `FuckHackTheULetsMakeBCS2`. That's not edgy posturing. That's a developer's scream fossilized in a directory structure.

The subtitle is carved into the repository itself: **Suffering & His Lament**.

### The Question BCS2 Asks

BCS1 asked: "What if eating broccoli could change the world?"

BCS2 answers: **"What if you changed the world and they destroyed you for it anyway?"**

Every heroic mechanic from BCS1 is here, recontextualized as tragedy:
- Broccoli collection → The lie of simple solutions
- Score thresholds → Meaningless benchmarks in a rigged system
- Epic music → The soundtrack to your persecution
- Visual novel resolution → The illusion of choice in a predetermined hell

### Legacy of Ashes

BCS2 was never submitted to a competition.

There are no academic papers analyzing its three-act structure.

There is no speedrunning community.

There is only the warning: *Some victories cannot be won. Some heroes cannot be saved. Some games should not be played.*

And yet—tucked into the surrender ending's final lines—there is a flicker:

*"Maybe... just maybe... I can make things right again."*
*"The only thing to do is continue on."*
*"So that I can live on. And extract my revenge against Samsung."*

Even in eternal damnation, Broccoli Consumption Man will not yield.

Such was his lament.

---

## BCS2 - where heroes go to die

*"I tried. I did. To save the children."*
*"But you wouldn't let me."*
*"You were always one step ahead."*

Built with MonoGame. Scored with despair. Played with regret.

**Broccoli Consumption Studios** didn't just make a sequel. They made a warning.
