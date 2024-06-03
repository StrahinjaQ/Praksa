Parametri koji se koriste u Bellman-Ford algoritmu:
1. Graph G(V, E)
   - V lista svih cvorova u grafu
   - E lista tuplova gde se svaki tuple sastoji od (u, v, w). ivica od cvora u do v sa tezinom w.

2. Source vertex s
   - proizvoljni cvor u grafu od kog se racuna najkraci put do svih ostalih cvorova.
  
3. Distance Array dist[]
   - niz gde dist[v] sadrzi najkraci put od glavnog cvora do cvora v.
   - dist[s]=0 ; dist[v]=inf

4. Predecessor Array pred[]
   - niz gde se nalazi prethodnik po najkracem putu pred[v] od cvora v
     
5. Number od Vertices |V|
   - ukupan broj cvorova u grafu
     
6. Number of Edges |E|
   - ukupan broj ivica u grafu
     
7. Iteration Counter
   - prati broj iteracija koje su se desile tokom relaksacijonog koraka. Relaksacija se vrsi |V|-1 puta.
   - (relaksacija je update-ovanje najkraceg moguceg puta)
     
8. Cycle Detection Flag
   -  boolean indikator koji detektuje ukoliko ima ciklusa u grafu sa negativnom tezinom

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
Parametri koji se koriste u A* algoritmu:
1. Graph G(V, E)
   - V lista svih cvorova u grafu
   - E lista tuplova gde se svaki tuple sastoji od (u, v, w). ivica od cvora u do v sa tezinom w.
     
2. Start Node
   - 
     
3. Goal Node
   -
     
4. Open List
   - Priority queue koji sadrzi cvorove koji su pronadjeni ali nisu procenjeni. Cvorovi se prioritizuju na osnovu ukupne cene.
     
5. Closed List
   - Set cvorova koji su procenjeni i koji ne moraju opet da se posete.
     
6. Heuristic Function h(n)
   - procena cene od cvora n do konacnog cvora. Moze da koristi Euklidske, Menhetn i Cebiseve udaljenosti.
     
7. Cost Function g(n)
   - cena od pocetnog cvora do dvora n
     
8. Evaluation Function f(n)
   - Ukupna procenjena cena najjeftinijeg resenja kroz cvor n.
   - f(n)=g(n)+h(n)
     
9. Parent Node
   - svaki cvor ima referencu na svoj parent node sto olaksava rekonstrukciju puta kad se stigne do cilja
     
10. Weights of edges
    - tezina prelaska sa jednog cvora na drugi
    - racuna se u odnosu na razdaljinu, vreme i potrosnju nekih drugih resursa
      
11. Neighboring Nodes
    - 
      
12. Path Cost
    - Ukupna cena kretanja od pocetnog do trenutnog cvora

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
