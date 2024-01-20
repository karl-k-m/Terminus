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

<!-- OVERVIEW -->
<h2 id="overview"> :page_with_curl: Overview</h2>

<p align="justify"> 
</p>

<!-- DEPLOYMENT -->
<h2 id="deployment"> :cloud: Deployment</h2>

<p align="justify"> 
</p>

<!-- DESIGN PRINCIPLES -->
<h2 id="design-principles"> :moyai: Design Principles</h2>

<p align="justify"> 
</p>

<!-- SERVER -->
<h2 id="server"> :file_cabinet: About the Server</h2>

<p align="justify"> 
</p>

<!-- NODE -->
<h2 id="node"> :pager: About the Node</h2>

<p align="justify"> 
</p>

<!-- ENCRYPTION -->
<h2 id="encryption"> :lock: Encryption</h2>

<p align="justify"> 
</p>

<!-- AUTHENTICATION -->
<h2 id="authentication"> :key: Authentication</h2>

<p align="justify"> 
  In Terminus, authentication exists to make sure that a device attempting to request or send data to the server is in fact an authorized node. This is handled via a hash challenge provided by the server to the client. Due to the fact that nodes are (besides requests to the server) airgapped and dedicated devices, using a hash challenge is appropriate and more secure than using a password. 

  Hashing is done using the SHA256 algorithm and each node has a device-specific hash salt which is randomly generated when a node is initialized. This hash is also stored on the server, which checks the hashed challenge data sent by a node to a hash which the server itself has calculated. This hash is exclusively used for authorization of nodes and nothing else.

  The primary goal of authorization is **not** the safeguarding of sensitive data (this is handled by encryption) but rather maintaining data integrity. By only fulfilling requests from authorized devices, the sending of bogus data is prevented.
  <img src="https://github.com/karl-k-m/Terminus/assets/74490726/dcc4e42c-11ca-4d03-870b-3ac8daae4d59" width="50%" height="50%"/>
</p>

<!-- CREDITS -->
<h2 id="credits"> :link: Credits</h2>

<p align="justify"> 
</p>
