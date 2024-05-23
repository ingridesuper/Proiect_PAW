# README.md


Proiect Programarea Aplicatiilor Windows - Aplicatie Furnizor de Telefonie


## Baza de date
in **bold** sunt PKs, in *italics* sunt FKs

| Entitati           |            |                |           |         |       |        |
| ------------------ |:----------:| --------------:| --------- | ------- | ----- | ------ |
| **Client**         | **ID**     | Nume           | Telefon   | Email   |       |        |
| **TipAbonament**   | **ID**     | Nume           | Pret      |         |       |        |
| **ClientAbonament** | **_ClientId_** | **_TipAbonamentId_** | DataStart | Discount |       |        |
| **Plata**          | **ID**     | *ClientId*     | *TipAbonamentId* | DueDate | Suma  | Statut |



#### Modelul bazei de date

- Baza de date porneste de la 3 entitati principale: **Client**, **TipAbonament** si **Plata**.

- **Client**: este o persoana care ori are in acest moment un abonament la firma noastra, ori a avut la un moment dat. 

- **TipAbonament**: un abonament este de 4 feluri, fiecare cu ID unic si pret.

- Un client poate avea mai multe abonamente simultan - relatia **Client**-**TipAbonament** este many-to-many, de aceea este mapata intr-o noua tabela: **ClientAbonament**. 
	- Totusi, am considerat ca un client nu poate avea acelasi abonament de mai multe ori, de aceea PK-ul tabelei **ClientAbonament** este format pur si simplu din concatenarea FK-urilor *(ClientId, TipAbonamentId)*. Un client poate avea un discount pentru un abonament pe care acesta il are, care e trecut in coloana *Discount* a tabelei **ClientAbonament**.
	- Practic, clientii ce nu apar in tabela ClientAbonament sunt fostii clienti.

- **Plata**: este tabela ce desemneaza platile ce trebuie efectuate (nu si cele deja efectuate) de un client pentru un anumit abonament pe care acesta il are. In tabela **Plata** sunt mai multe coloane:
	 - *ID* : PK
	 
	 - *(ClientId, AbonamentId)* : FK din tabela **ClientAbonament**
	  - De data asta, un client poate avea mai multe plati de efectuat pentru acelasi abonament, in caz ca are si plati restante din trecut. 
	 - *DueDate* : Data pana la care plata trebuie efectuata
	 
	 - *Statut* : *Upcoming* daca duedate-ul este in viitor, *Restanta* daca acesta a trecut fara ca plata sa fie efectuata.
	 
	 - *Suma* : suma ce trebuie platita, calculata in baza pretului abonamentului (via *TipAbonamentId* din **TipAbonament**) si a discountului pe care il are clientul pentru acest abonament (via *ClientId, TipAbonamentId* din **ClientAbonament**).



## Observatii & minusuri

- Aplicatia este facuta in asa fel sa respecte logica modelului de date. De exemplu:
	 - Daca vom schimba pretul unui tip de abonament, toate platile pe care trebuie sa le efectueze oamenii ce au acel abonament se vor schimba la randul lor.
	 - Daca am vrea sa schimbam data la care un client si-a achizitionat un abonament si clientul respectiv are de efectuat o plata pana intr-un due date mai devreme decat data de start, aplicatia nu ne va lasa.
	 - Si altele;
	 
------------
	 
	
- Totusi, minusul este ca nu am implementat triggeri in baza de date. In acest moment, toate datele din tabele respecta logica (pretul unei plati este calculat conform discountul clientului si a pretului abonamentului, due date si data start sunt puse in ordine logica etc), dar asta pentru ca atunci cand le-am introdus am avut grija sa fie asa.
- Cu alte cuvinte, daca interactionam cu baza de date doar prin intermediul aplicatiei, records-urile introduse sau modificate o sa-si mentina logica. Dar daca interactionam direct prin SQL Developer, nu neaparat, pentru ca nu am mai implementat triggerii respectivi.
- In plus, nu stiu cum as putea sa fac coloana statut din tabela plata sa se schimbe mereu, automat, in functie de ziua de azi.
