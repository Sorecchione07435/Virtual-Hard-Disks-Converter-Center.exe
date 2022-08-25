Virtual Hard Disks Converter Center è un software Open Source per la conversione dei dischi virtuali per le macchine virtuali

Questo programma potrebbe essere utile se si ha creato una macchina virtuale in un'altra piattaforma per es. abbiamo installato Windows 7 su VMware Workstation e il formato del disco è diverso da VDI ecc.., è possibile utilizzarlo per provare a far partire una disco rigido virtuale non creato da VirtualBox.

Questo software necessita di VirtualBox installato nel computer perchè ha bisogno di una riga di commando che permetta la conversione dei dischi, utilizza VBoxManage

### Richiede
- Oracle VM VirtualBox

### Formati Dischi Virtuali Supportati

- VDI - VirtualBox Disk Image
- VHD - Virtual Hard Disk
- VMDK - Virtual Machine Disk 
- VHDX - Hyper-V Virtual Hard Disk (Solo Conversione) (Non sarà possibile convertire dischi in VHDX)
- HDD - Parallels Hard Disk
- QCOW - QEMU Copy-On-Write
- QED - QEMU enhanced disk

### Come Installarlo Step per Step

1) Per prima cosa è necessario cliccare  l'URL in basso

2) Dopo il Download avviarlo e procedere con l'installazione, se non hai già installato VirtualBox sul tuo computer bisogna spuntare "Installa Oracle VM VirtualBox"

3) Prima di completare l'installazione di VHDs Converter Center verrà avviata anche l'installazione di VirtualBox 6.1.36
E cliccando su "Fine", sarete pronti per utilizzare il Software.

### Come Utilizzarlo

1) Una volta aperto il programma cliccare sul primo pulsante in alto "Sfoglia..." e andare a selezionare il file da convertire e selezionare il Formato 
2) Fare la stessa cosa sotto ma bisogna salvare il disco virtuale futuro che verrà convertito, selezionare un formato diverso e cliccare su "Avvia"
3) Quando verrà mostrato il messaggio "Conversione Disco Virtuale Completata" significa che la conversione è andata a buon fine

Quando la conversione sarà andata a buon fine si potrebbe provare a creare una macchina virtuale e provare ad assegnargli il disco virtuale convertito per provare se funziona

### VHDs Converter Center si Blocca e non si puo più chiudere

Se in caso il programma si blocca durante la conversione del disco probabilmente mancherà un valore nelle variabili d'ambiente di Windows

Come risolvere questo problema? Semplice!

Accedi al Pannello di Controllo e andare su Sistema e Sicurezza -> Sistema -> Impostazioni di Sistema Avanzate e cliccare su "Variabili D'ambiente..."

Su variabili di sistema andiamo a cercare la variabile nominata "PATH" e selezionarla, cliccare su "Modifica..."

e inserire la directory di installazione di VirtualBox.

```bash
;C:\Program Files\Oracle\VirtualBox
```

Per accedere alla propria directory di installazione di VirtualBox fare tasto destro su "Apri percorso file" nel collegamento di VirtualBox nel Desktop e copiare il percorso


Dopo averlo inserito cliccare 3 volte su OK e chiudere il Pannello di Controllo. 

A questo punto il problema è risolto

### Download

- Download Ultima Versione :  https://github.com/Sorecchione07435/Virtual-Hard-Disks-Converter-Center.exe/blob/main/VHDs_Converter_Center_x86_1.0.0.0.exe

### Avvisi

- Il progresso della conversione non è esatto, anche se il progresso arriva a 100 questo non vuol dire che la conversione è stata completata, sara necessario attendere più tempo del previsto

- Non è ancora possibile annullare la conversione, verrà introdotto in una nuova versione



