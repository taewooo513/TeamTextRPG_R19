using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Scene
{
    public class TestScene : Core.SceneManager.Scene
    {
        public void Init()
        {
        }

        public void Release()
        {
        }

        public void Render()
        {
            TextIOManager.GetInstance().OutputText(TimerManager.GetInstance().GetFrame().ToString(), 0, 0);
            //{

            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 0, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 1, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 2, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 3, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 4, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMWWNNXXXNNWWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 5, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMWWXKOxdoc:::::::cloxkOKXNWMMMMMMMMWWNXKK0KKXNNWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 6, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMNOdlcc;'.....'',:llllcc:::coxOKK0Okxdollc:;,'';cdkO0KKKXXXXXNNNNNNNNNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 7, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMWXkoclol:,,;:loooc,,lkOOOOkxdl:;,,;;:cc:;,,,,,,,'',;;;;:loxkOOOOOOOOkkxxxO0XNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 8, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMXkllodl;...;lxOOOOOd,'ck000000OOxo::col;,,;codxkkkkkxdo:;,'',lxOOOOOOOOkxdolcloxO0KXNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 9, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMW0lcoo:,,:lol:,;lxOO0Oo''lO000000OOkd:,'';lxkO0000000Okoc;''....,cdkOOOOOkdoc;,'',:looodkKWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 10, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MWk::l:''cdxxxdl:'.'ckOOkc.,xO00000Oko:',cdOO0O00000Okdc,..,;:::;,'',:ldOko;,,,:cldxkOOkxdloxXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 11, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("WO;;c,.:ddc;,;;;;.  .;dkOd''oO000Oko;',lxO00000000Okl;,,;codxxxxxol:,,:lkxc'..',,;:cldkO000Oxx0NWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 12, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("0c;c'.:o:...'cdxd;.,;';okx;.ckOOkd:',lxO00000000Okl;';okOOO00OOdc;,;coxkOOkl,.,;:;,'',:okO000Okk0NMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 13, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText(",.:;..,'.,,. .,cc'.lxc';dd,.lkkd:',lxO000000000Od:,:dkO000000Oxc;:okO000000Oxc''cdxdl:,,:dk0000OO0NWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 14, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText(";.;'  ..,l,.......:xOd,.:c.,oxl,'cxO0000000KK0xc;cxO000000000OOkkO00000000000Od::dO0OOxl;;cdO0000O0XWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 15, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("d...   .,;......,lkOOx,...,lo:';oO000000000KOd;;oO000000000000000000000K0000000OkO00000Okl;;lk000000KXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 16, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("O;  .,. .',,;;codxdoc;..;ldl,':xO0000000000kl,:x0KK000000O000000000KKKKKKKK0000000000000OOxc;ck000000O0XWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 17, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("c'  .cl;',;:::::;;;;:coxkxl''lk0000000000Ox:'ck0K00000Okook00000000KKKKKKKK0000000000000000Od:ckKKKKK0Ok0XWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 18, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText(" ....':lllcccllodxxkOOOOkc.'lk0000000000Od;'ck0000000Ox:'ck0000000KKKKKKKKKK00000000000000KK0d:ckKKKK00Oxx0WMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 19, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("';::;,''':coddxkkkkOOOOkl''lkO000000000Od;,lk0000000Ox:.;xO0000000KKKKKKKKKK000000OOO00000KKK0d;ckKKKK00OxokNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 20, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText(".,,,,;,...'',;:ccllooddl'.ck00000000000x:'lk00000000kc.'oO00Oxdk000KKKKKKK0000000OxlcxO000KKKKOo;cOKKKK00OxokNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 21, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("''..... .''..',,,,,,;c:'.:k00000000000kc'ck00000000Od,.ckOOOx:;dO00000000000000000kc';dO000000KOl,lOK00000OkdkXMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 22, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("kl.....    ..',,:c:;'...;xO0000000000Oo,;xO00000000k:.,dOOOOo,;xO00000000000000000Ox:.,dO0000000x;;dO000000OkdkNMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 23, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText(";',;:;.. .....'',;:;'  .oO00000000000k:,oO0000000Ox:..;xOO0Ol,ck0000000000000000000Ol..,dO000000Ol':k0000000OkxONMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 24, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("';cc:',;''c;';c:;;;;,..;xO000O000000Oo;ck000000Oko;. .ck000k:'lO000000000OkkkO00000kc..';oO000000x;,oO00000000OkOXWMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 25, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("c;;;',dd,,cc;lkOkkkko'.ck00000000000xc:xO0OO00ko:,;'.'oO0OOk:'lOO0000OOOOxc;dOOO00Oo',xx:;oO00000Ol,ck000000000OkdkKWMMMMMMMMMMMMMMMMMMMMMMM", 0, 26, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("Kkl;:dKk,,cc;:xO000Oo'.lO0000000000kl:oO000Okd:;cxkc..cxOOOkc'ckO00OOOOOkl';xOOO0Oo,'oKXk;,oOO0000x;;x00000000000kddkKNWMMMMMMMMMMMMMMMMMMMM", 0, 27, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MWNXXNWk,,cl;,oO000Ol.'oO000000000Od:cxO0OOdc:lkKNKo'..;coddc.,dOOOOOOOko,'oO0OOkl'..:odd:.,oOO000kc,oO00000000OOOOkdodOXWMMMMMMMMMMMMMMMMMM", 0, 28, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("0NMMMMW0:';:'.ck000Ol',dO000000000kc:dOOkoc;:oxdoc:,.......'. .ckOOO0kxo,'lkkxl;'. .,;,...  .:okO0Oo;cO0000000Oo:cdkOkdoONMMMMMMMMMMMMMMMMMM", 0, 29, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("xkKWMMMN0o;';ccx000Oo',dOOOOO00OOOd;:ddc,............';c:..'. .'lkOOxl;''cdo;......cOKKkc.    .ckOOx:ck0000000Od,,okkkO0XWMMMMMMMMMMMMMMMMMM", 0, 30, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("N0kOXWMMMWOo0NkdO00Od,,dO000000OOOo'',...,'. ..:oddc,'.,oo:,..,c:coo;...':,. .',;;:oxkkOkc'  .;okOOkc:x0000000Ox;:0WWWWMMMMMMMMMMMMMMMMMMMMM", 0, 31, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MWXkx0WMMMKkKMKddO00x,'oO00000000Od;;lol:,'..,:codxkdc'.,k0d;,o0Odlccclodkd;..,clllcccoxo;.  .,ldkOkccx0000000Od;:0MMMMMMMMMMMMMMMMMMMMMMMMM", 0, 32, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMN0xkXMMXkKMW0dxO0k:'ck000000000ko;co;..;:cccccclxkl..:0WWXKXWMWNNNWWWMMW0c..lk0Okxdxxdl:,.,lolloc,:xO000000Od,cKMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 33, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMWXOkKWXkKMMW0dxOOl';x00O0000000Ol'...;dkkkxxxxxxko',xNMMMMMMMMMMMMMMMMMWO,.ck0K000OkkOKX0OKXKOxl;;:okO0000Oo,oNMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 34, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMN0k0KkKMMMWKxxkx;'oO0000000000kc'',,oO0KK00000Ox;'dNMMMMMMMMMMMMMMMMMMNkl::coodoc,,lKWMWMWNXXK0ko;:dO00Ok:;kWMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 35, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMW0xdxXMMMMMNOxxl';xO0OO0000000xllxkOKX0xoloxxo:,c0WMMMMMMMMMWMMMMMMMMMWNKkdlcc::ldOKNNNWNNXXXXXKx,,dO0Od,:KMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 36, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMW0dOWMMMMMMWXkl'.:xO00000OO000KXWWWWNOl::::::cxXWMMMMWMMMW0xkXWWMMMWKk0NMWNXKKKXXXXXXXXXXXXXXXXO:'lOOx:'dNMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 37, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMWNWMMMMMMMMWNOc..cxO000000000KXXKKXNX00K00O0XWMMMMWKkxkOx:.'coxKNNKl'lXMMWNXXXXXXXXXXXXXXXXXXKx,,okko';0MMMMMMMMMMMMMMMMMMMMMMMMMMM", 0, 38, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMMWWWNKx;..:xO00000Oxdk0OoclkKXXXXXXNNWMMMMWXkolc:cdxocc:cl:,:OWMMWNNXXXXKOxolllodOKXKk:'ckOx;'dNMMMMMMMMMMMMMMMMMMMMWMMMMMM", 0, 39, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMMMWXOoc;;:cccoxO0000Ol':dxkdc:oOKXXXXXNWWMMMMMWWNXXNWMWNXOxdxOXWMMMMWNNX0xllodddoc,,okd;;lkOxc'lXMMMMMMMMMWMMWWWNXXKKKXWWMMMM", 0, 40, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMMMWKd:,:oxkO00OxodkO00Od;;lllodl::lkKXXXNNWMMMMMMMMMMMMMMMMMWWMMMMMMMMMWNOc:xXWMMMMNk;';:lxOOkl'cKWWNNNXK0Okxxdolcc::::;:kWMMMM", 0, 41, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMMWNx;,cxO00000000kdoxO00Od;'''',;;,..,:ldk0KXNWWWWMMMMMMMMMMMMMMMMMMMMMMNk::kWMMMMMMMXl':dkkkxl,':lll::::;;:::cclloddxxd;.oNMMMM", 0, 42, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMWNd',dO00000000000Oo:lxO0Od;.''.....    ..,;:cclodxO00KKXXXXXXNNNNNNNNK0o;cOXK0Okxdooc'.,::::::::ccloodxxdccok00000000xc':0WMMMM", 0, 43, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMWNx,,d0000000000000x:,codkOOxc:dkxoc;,................',,,,,,,;;::::;;;,'':ddc;;;;::ccloodxxkkOO00000000Oo;,::;cdO000Od;'lKWWMMMM", 0, 44, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMWXc'lO000000000000x:,oKKkddkOkllkNWWNK0Oxdl;'.....'..............',;::lodoc,;col:;lk0000000OOOkkxxdoollc:'.;oxdl;:lkkl,;xNWMMMMMM", 0, 45, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMWO;,d000000000000k:'oXMMWXkoodxdoxKWMMMMMMWNKOdc'';;............'oKNNWWWOc,:ol:;c:',colcccc::::ccclloodxxkkxc:col'';;'c0WWMMMMMMM", 0, 46, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMWO,,d00000000000Oc'cKMMMMMWKkdooolcd0WMMMMMMMMMN0o,..............lXMMMXd,,::;;odl:;cloodxkOO0KXNNWWWWMMMMMMMNk;.,;,',dXWMMMMMMMMM", 0, 47, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMW0:,o00000000000d,;OWMMMMMMMMWX0OkkkKWMMMMMMMMMMMNx'.....,,......oKXKk:':c,,ldl:lOXWWMMMMMMMMMMMMMMMMMMMMMMMWO;;l:':OWMMMMMMMMMMM", 0, 48, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMWXo'cO000000000k:'oNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMO;.....;;'....';:;,';oOOo;,',xNMMMMMMMMMMMMMMMMMMMMMMMMMMMWk,'''c0WWMMMMMMMMMMM", 0, 49, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMWWk,;x00000000Oo';0WMMMMMWWWNNXXXK0Okxk0XWWMMMMMWXo',clooddxxxkkOkl''ck0000xc,dNMMMMMMMMMMMMMMMMMMMMMMMMMMMMWk,.'lOXXXNWWWMMMMMMM", 0, 50, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMMMMMMMMWXl'cdlc:;;;;;'.;dkxddollcc:;;,,;::cc:;;cldxxxxl;,cOWWWWNNNXXK0ko,;dO000000o;kWMMMMMMMMMMMMMMMMMMMMMMMMMMMMWx,;d0KKKKKXXNWWMMMMM", 0, 51, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMWNK000Okxc..',cloddoolc;,...,cc;..,,'..,:oxOOkxdlc;,,,,;cdxdolc:::ccc,.'ck00000000l,xWMMMMMMMMMMMMMMMMMMMMMMWWNNXKOl'l0KKKKKKKKKXWWMMMM", 0, 52, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMNk:;:::::,.'lOKKKXKkllx0Od:',o0x,';ccccc:;;;;:cllc;,',:clolc:,...',;;';dO00000000Ol,dWMMMMMMMMMWWNNXKK0Okxdollcc::::cd0KKKKKKKKKKXWMMMM", 0, 53, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMWNKOOO000Ol.;kKKKKKKOo,,o0K0d,'d0kl:;,,,;:cclllccc:;,,,,;:::;'...,,'.'ck0000000000Ol,oXXK0OOkxdolc::;;;;;::clodxkkO00KKKKKKKKKKKKXNWMMMM", 0, 54, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMWWXKKKKKKKd,'o0KKXKKKKk:,dKK0l.:OKKK0Oxdoc:;;;;;;:ccllllllllcc:;;;;;:dO0000OOkkxdol;.';;,,,,,;::cloddxkO00KKKKKKKKKKKKKKKKKKKKXXNWWWMMMM", 0, 55, ConsoleColor.Yellow);
            //    TextIOManager.GetInstance().OutputText("MMMMMWWXKKKKKK0o''lOKXKKKKKOdkKKO:.:OKKKKKKKKK0Okxoc;,....',;:lodxkkkkxkkOkxdol:;,,'....',;:lodxkO0KKKKKKKKKKKKKKKKKKKKKKKKKKKKKXNNWWWWMMMMM", 0, 56, ConsoleColor.Yellow);
            //}
        }
        /*
         

         */

        public void Update()
        {
        }
    }
}
