<p align="center"> 
  <img src="Terminus/assets/img/TerminusLogo.png" alt="Terminus Logo" width="100px" height="100px">
</p>
<h1 align="center"> Terminus </h1>
<h3 align="center"> A chat service for the overly paranoid. </h3>

<h2 id="table-of-contents"> :book: Table of Contents</h2>

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#tl-dr"> ➤ TL;DR</a></li>
    <li><a href="#faq"> ➤ FAQ</a></li>
    <li><a href="#overview"> ➤ Overview</a></li>
    <li><a href="#deployment"> ➤ Deployment</a></li>
    <li><a href="#design-principles"> ➤ Design Principles</a></li>
    <li><a href="#server"> ➤ About the Server</a></li>
    <li><a href="#node"> ➤ About Nodes</a></li>
    <li><a href="#encryption"> ➤ Encryption</a></li>
    <li><a href="#authentication"> ➤ Authentication</a></li>
    <li><a href="#credits"> ➤ Credits</a></li>
  </ol>
</details>

<hr>

<!-- TL;DR -->
<h2 id="tl-dr"> :pencil: TL;DR</h2>

<p align="justify"> 
  Terminus is a simple chatting service based on <a href="https://en.wikipedia.org/wiki/One-time_pad">OTP encryption</a>. The goal of the project is to create a chatting service that is theoretically "unbreakable" via the use of designated client devices (Raspberry Pi-s) called nodes. The core design principles are based on the assumption (correct or not) that all centralized servers are vulnerable when faced with a sufficiently motivated third party.

  Terminus works by generating and sharing OTP keys between nodes in an exclusively airgapped fashion. All messages stored on the central server are encrypted with keys which only exist on the nodes themselves. As such, the server can be inherently unsecure as long as the physical security of the nodes is guaranteed.
</p>

<hr>

<!-- FAQ -->
<h2 id="faq"> :question: FAQ</h2>

<p align="justify"> 
  <h3>Why?</h3>
  No particular reason. This project was created mostly for personal entertainment and has very few (none?) true use cases. It exists for the sake of existing.
  
  <h3>Are you a criminal?</h3>
  I'll tell you a secret - I pirated my university textbooks (don't tell the police).

  <h3>This sounds pretty cool. What's the catch?</h3>
  Consider the following:
  <img src="https://imgs.xkcd.com/comics/security.png" />
</p>
