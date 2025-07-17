using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;
using TeamRPG.Core.SceneManager;
using TeamRPG.Game.Object.Data;

namespace TeamRPG.Core.EncounterManager
{
    using SceneManager = SceneManager.SceneManager;

    public class EncounterManager : Singleton<EncounterManager>
    {
        private Dictionary<string, EncounterData> encounters = new();

        public void Init()
        {
            // 초기화 로직
            encounters.Clear();

            string image01 = """
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡢⣖⢖⣖⣖⢵⡱⠅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣰⢪⢎⡏⡗⣝⣼⢞⣾⣺⢮⣚⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢤⢺⢺⡸⣜⣵⢟⣯⢯⣳⣟⣗⣯⢯⡯⡷⣭⢣⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡰⣝⢮⢣⣳⣟⣽⣺⡽⣞⣯⢷⣻⣺⣳⣟⢷⣭⢿⢘⢜⢤⢠⠠⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡺⣕⢵⡯⣷⣳⣗⣯⢯⣟⡾⣽⣳⣻⣞⣾⣻⣺⢧⣧⣿⣦⣅⣱⡵⣶⢷⣶⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡠⡜⣞⢼⣯⣻⣺⡵⣟⡾⣽⣞⣯⣷⣻⣞⣾⣞⡾⣽⣻⣗⡷⡯⣞⣿⣻⢿⢽⢮⣷⢯⣷⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⢳⡫⡯⡪⠛⠚⠊⠓⠙⠉⢙⠑⣟⣷⣟⣞⡿⣞⣿⣽⡿⣾⣟⣾⣫⣟⡷⣯⡿⣯⡳⡷⣽⣗⣿⢵⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠙⠈⠁⠁⠀⠀⠀⠐⠐⠤⢮⣵⣭⣮⣷⢿⢽⢾⣻⢽⢞⡿⣯⣿⣾⣻⣗⣽⡳⢍⢊⠒⡽⣺⣗⣿⡽⡦⡀⠀⠀⠀⠀⠀⠀⠀⢠⡀⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣐⣤⣴⡽⣿⢾⣟⣷⢯⣯⢯⣗⣇⢏⢯⣞⣿⣺⣯⢿⣯⣻⣅⢫⢚⡮⣞⣿⣷⣻⣟⣿⢧⣕⣐⠰⡠⡠⡠⣔⣞⣮⣎⠖⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠴⠚⠓⢟⣾⣟⣯⣟⣾⣞⣟⡮⣗⢗⢵⣳⢵⣳⣗⠿⣽⣻⢎⡿⡾⣞⣯⣿⡻⣟⣾⡿⣯⡿⡽⡯⡿⣽⢾⣤⢵⣕⢿⡾⡞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠊⠀⢠⣾⣻⡾⣯⣷⢿⡵⣯⢷⡻⣝⢽⣳⡿⡝⡽⣞⢯⣚⡮⢟⢞⢽⢯⡺⣵⣻⡿⣽⢿⣿⢽⣻⣽⢿⣷⣟⣾⣝⢞⢯⠫⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠲⣺⡟⣾⡽⣟⡯⣟⣟⢿⢽⣫⣟⣺⣝⡷⡫⣓⢽⡺⣝⠇⣥⣣⡫⣏⣯⣻⣞⠨⡫⢯⢻⣟⡿⣟⣾⣻⣺⡽⣟⡿⡱⣽⣤⣧⢣⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠊⣠⣖⣶⣻⣽⣟⣯⣿⣯⣿⡾⣞⢾⣫⣺⢪⡳⣝⢟⣇⢽⡹⣘⢇⢥⠸⣺⢼⣗⡼⣎⡇⣿⢽⢯⣟⡿⣷⢿⢵⣟⢾⣳⣿⣻⣻⣪⢧⣀⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠞⠁⢀⣾⣞⣗⣯⡷⣷⣻⣞⣯⡷⣟⣾⣺⢷⣯⣎⡯⣳⣝⡾⡕⣮⠳⣫⠸⢕⣷⣻⣳⢇⣏⢿⣽⣽⢳⣻⢯⣿⢯⣻⣷⣻⢿⣻⡏⠳⠽⣽⢬⢣⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠀⣠⣿⢯⣿⣽⣗⣟⣗⣟⢗⠧⣏⢧⡣⡯⡫⡣⣇⡫⡫⡺⠮⣳⣪⡺⠼⢬⢝⣗⣗⣯⣗⡮⣿⢷⣫⢗⡯⣟⡾⣻⡿⣽⢿⢿⡛⠀⠀⠀⠀⠙⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢔⡿⡹⣵⡿⣞⣗⢳⢹⢺⢦⢓⡊⠗⣫⢷⡸⡸⣼⣽⢮⡪⢮⡲⣨⣙⣙⣝⡵⣵⡻⣞⣷⢟⣿⣻⡽⣵⢿⡷⣟⣯⢯⢯⢿⣻⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠊⠉⢤⢞⣿⣻⣏⣢⣁⡧⣏⣧⢕⣌⢵⣱⣿⣯⣾⣟⣮⢳⡹⣕⠞⠁⢕⠒⣓⠝⠾⡹⡎⡯⣿⢾⢯⡿⣝⣝⡯⣟⢾⢽⣽⢿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠔⠒⣿⢯⣿⣗⣯⢯⢯⡻⣎⢆⠪⢻⣻⣷⣿⣯⣷⣿⢽⣚⣅⣕⣜⢴⠣⢏⢛⢙⣛⢫⡻⣩⣳⠙⢫⣷⣳⢝⢽⢯⡿⡝⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣟⢯⣷⢿⣺⢽⢯⢞⣽⣂⠣⣅⡷⣯⣷⣿⣟⣿⣯⢷⣗⣗⣗⣵⣹⢵⢽⢵⡯⣷⣝⢾⣽⣷⠀⠈⠚⠻⡮⡗⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠏⢺⢸⣯⡿⣯⡿⣾⣻⣽⢾⡵⣗⣯⣗⢯⢯⢟⣷⣟⡯⣯⢗⡽⣸⢮⢳⢝⢮⣟⡷⣗⡿⣺⣟⣶⢦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠈⣿⣞⣿⣽⣯⣿⢾⣟⣿⣻⣽⡷⣗⡯⣯⣻⢜⣽⣽⢯⣻⣪⢷⢽⢮⣻⡲⣞⣯⣱⢽⣯⣿⣻⣟⣯⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠜⠊⣼⣞⢾⣿⡾⣿⡿⣿⣯⣿⢿⣻⣯⣷⣟⢮⡫⣿⣽⣻⡾⣝⡽⡺⣎⣽⡽⣷⢽⣽⣟⣿⣽⣯⢿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠋⠘⣿⣯⢿⣽⣟⡿⣾⣻⣿⣿⢿⣷⢿⣯⠿⣔⠯⣟⡯⡯⡿⣽⣳⢯⢯⣻⣯⣷⢿⣻⢽⣾⣟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⡰⣻⣯⣿⣺⣗⣿⢹⣿⡿⣾⣿⣟⣿⣻⣟⣞⣿⡾⣟⣯⣿⢷⣿⣻⣿⣻⣗⣟⡿⣽⣿⣽⣽⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣷⢯⢷⣟⣾⢹⣿⣟⣿⣟⡾⣯⢷⡯⣗⣗⣽⢽⡾⣺⡿⣝⣿⣯⢿⣽⢷⣻⣗⣟⡾⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣿⣾⡇⠮⣗⢻⡌⣾⣿⣽⣿⡽⣟⣽⡺⣟⡮⡮⡷⣟⣷⣻⢿⡽⣾⠯⣾⢿⣻⣮⣷⡿⣽⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⡋⣧⠀⢹⠈⣆⢻⣽⣷⢟⣟⡟⣞⡽⣗⣟⣞⡾⣽⣞⣞⡯⣻⢿⢽⣟⡯⣷⢯⣷⡿⣟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡂⠈⠆⠀⠃⣘⠾⣿⣽⣻⡺⣪⢗⡽⡵⣳⡣⡯⣺⡷⣗⣿⣽⣯⣷⣗⣯⢿⣻⣯⢿⣽⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠣⠀⠀⠀⠁⠀⣴⣟⣾⣪⢟⡼⡵⡽⣝⢮⢞⣞⢮⢿⣳⣟⡾⣯⣿⣻⣽⡿⣽⣾⣟⡷⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⣾⣿⣻⣽⣾⣽⣺⣪⢯⣞⣗⡯⣳⡫⣟⣞⡯⣿⣿⣽⢿⣽⡟⣞⣷⢯⣟⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣸⣯⣿⣽⣯⡿⣽⡾⣿⢾⣮⣿⣺⣎⡷⣳⢯⣳⣻⣺⣻⢾⢝⣯⢟⣿⣟⣯⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⢿⢷⢿⢾⣻⢷⡿⣯⡿⣞⣗⣯⢿⣻⣞⣳⣟⣟⣿⣻⣽⢗⣯⣿⣻⡾⡟⠎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⡻⡜⡕⢕⢍⢗⢏⢟⢾⣻⣯⣿⣯⣷⢿⣮⣗⣝⣯⣻⣮⢯⣾⣷⡿⣟⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢮⢳⢕⣽⠾⡼⣴⣱⡱⡕⡝⡮⡷⡿⣞⣿⣽⣯⣿⣻⢽⣞⣿⣻⢷⣻⢿⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣮⣾⢯⡳⣹⢝⢮⢻⣻⣜⢞⡽⠀⣿⢾⡿⣾⢾⣺⣟⡾⣞⣾⢝⣺⢽⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⡽⣺⣽⣇⢝⢜⢝⢵⣻⢿⣽⡽⡊⢀⣟⣿⡻⣟⡿⣞⢷⢿⢿⣟⡿⣾⢷⠯⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                """;

            string image02 = """
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⢆⢤⢀⡀⠀⠀⠀⠀⠀⡀⠄⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣞⢮⢲⣳⡣⡣⣕⢤⡀⠀⡐⠀⠠⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⠋⠁⠀⠀⠙⢾⣕⢆⠿⣵⠪⢀⠌⡀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠀⠀⠀⠀⠀⢸⢞⣎⢞⢑⡏⣟⢾⣲⣟⢶⡺⠚⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⡤⣟⠦⡽⡱⣹⡾⣿⣁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣰⡻⡽⣖⢧⣟⢽⣺⢘⠨⠋⠑⢯⣫⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠈⠘⠑⠛⠊⣓⢵⠯⣺⢯⣟⢿⡳⣔⡸⡸⡲⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠣⠠⡜⡿⣻⢺⢕⢞⡝⡔⢕⠦⢳⢿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠐⠫⠚⢩⣽⡳⡬⡮⣮⡯⡋⡑⠔⠽⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢆⠀⠀⠀⣯⢞⣾⣽⢿⢝⢷⡕⢄⠈⡊⢻⣿⣦⡀⠀⣀⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣔⣔⡆⢀⣀⡤⣯⢾⡽⣟⣞⢝⢢⢽⠯⡆⡂⢌⢘⢜⣿⣻⡿⣿⣿⣷⡄⠀⠀⢀⢤⠴⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠺⢽⣾⡷⣿⢿⣻⣯⣻⣺⢽⣵⣟⠀⠹⡜⣔⣵⡳⠛⠝⠉⠈⠉⠿⣻⡤⠔⠉⠁⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠙⢹⣿⢽⢼⡵⣟⣽⣽⣹⡃⢨⢿⢳⢵⣯⠀⠀⠀⣠⠔⠊⠁⢱⡀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠐⠤⢤⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⣿⢿⣽⣽⣽⡾⣿⣾⣳⣇⢁⢟⡧⡿⡹⠤⠒⠉⠀⠀⠀⠀⣸⡧⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠈⠲⡐⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⢿⣟⣯⣯⡿⣽⣷⢹⣿⣯⣿⣳⣽⣺⣏⢀⣀⣀⡀⠀⠀⠀⠀⡼⡯⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢦⡈⠢⠀⠀⠀⠀⠀⠀⢼⣻⡯⣗⣯⣷⣿⢟⡮⡿⣞⣯⣿⣿⣟⣯⣿⣿⡋⠀⠀⠀⠀⠀⡰⠏⠁⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⣆⠕⡄⡰⣩⠀⠠⣿⢯⣯⣳⣟⢻⢩⢿⣟⣿⡻⡽⣿⣯⣿⣿⣿⣽⣅⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⢄⠀⠀⠀⠀⠀⢀⣀⠿⡎⡱⣸⣺⡚⣔⡿⣹⢚⡼⣼⣽⢯⣻⣪⣷⡫⠮⡷⡿⠿⣷⣿⣻⠿⠿⡾⡶⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠈⠳⢄⠄⠄⠀⡏⠪⣻⣛⣯⣚⡊⠊⠓⣯⣿⣽⢽⣷⣟⡿⣝⣗⣽⢎⡭⣻⣷⠀⠙⠾⠹⠫⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠉⠛⠾⠆⣀⠓⢫⡷⡆⠀⠀⠀⠹⣷⣿⢿⣻⡟⣽⣷⢷⣽⣯⣟⣯⣻⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⡀⠀⠀⠀⢀⣴⣟⣯⡾⣿⡀⢹⡕⡅⠀⠀⠀⢹⣽⣿⣿⡿⣿⡿⣿⣺⣯⣷⣻⢮⣟⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⡇⠀⠀⠀⣮⣷⣝⡈⢞⣷⠗⢐⢷⠈⠀⠀⠀⠈⠈⠑⣭⣟⣿⣿⣯⣿⣾⣯⣿⣿⣿⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠐⡄⠀⠀⠈⢳⣳⣯⢿⡾⣁⣪⠃⠃⠀⠀⠀⠀⠀⠀⢱⠉⠛⠽⣿⡯⡿⣽⣯⣷⡿⢯⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠨⢦⡀⠀⠀⠀⡁⣇⢦⠪⢚⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣻⣯⢿⣟⣯⣿⠃⠀⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠈⠹⠋⠙⡏⠁⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢿⡟⠋⣿⣽⣾⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠙⠋⠀⢠⣿⣺⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢷⣵⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠲⠺⠫⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                """;

            string image03 = """
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠄⠂⡐⢐⢈⢂⠅⡅⡕⡌⣆⢆⣄⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢀⢄⠢⢊⠌⠌⡌⡪⡪⡤⠀⡐⡔⡔⡔⡕⡔⣱⢰⡕⡷⢽⢺⢹⢪⠻⡜⡵⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⡂⠅⡁⢂⠐⡈⢄⢪⢸⡨⣪⠎⠀⠀⡇⡇⡊⡢⢣⠣⡣⡣⡣⡣⡣⡣⡣⡃⢇⢪⢸⠘⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⡀⡂⠄⡂⡐⢄⢢⢪⢜⢮⢳⢳⠹⡌⠀⠀⠀⠀⠁⠑⠈⡢⢑⠜⡨⡊⢎⢪⠢⡣⠪⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⢌⠢⡪⡸⡰⠱⡱⡑⢇⠫⡊⡪⢢⢣⢫⠀⠀⠀⠀⠀⠀⠀⠐⠡⡊⠔⢌⢊⠢⡃⡇⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠑⠈⠀⠀⠅⠂⠌⡐⠡⢊⠌⢆⠣⡣⢅⠀⠀⠀⠀⠀⠀⠀⠡⠠⢁⠂⠢⡑⢅⢃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠠⠁⠂⠌⡂⠕⢌⠢⡂⠀⠀⠀⠀⠀⠀⠌⢐⠠⢈⢐⢈⠢⡡⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠡⠈⠄⠅⡂⡑⡐⢅⠪⡀⠀⠀⠀⠀⠀⠌⡀⢂⠐⡀⠢⡑⡐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⡁⠅⠡⢁⢂⠢⢑⠐⠅⡊⠄⠀⠀⠀⡈⠠⠐⠀⢂⠨⢐⠨⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠠⠀⠂⡁⢂⢐⠨⠐⠨⡈⠔⠡⠂⠀⠠⠀⠐⠀⡁⠄⠐⡀⡂⡪⠨⠨⡈⡂⡂⡂⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⢀⠁⠄⠀⢂⠠⠂⠡⠡⠠⠡⠡⢑⢀⠂⡈⢀⠁⢀⠐⠀⠄⢂⠢⡑⢅⢂⠪⢐⠨⡨⡢⡪⡲⡱⣲⢔⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠄⢀⠡⠀⢂⠁⠅⠌⡐⡁⠅⡂⡂⢂⠀⠄⠠⠀⡀⢁⠐⠠⢂⠪⡢⡑⠌⢔⢑⢬⢪⢎⣗⣝⢮⡳⣕⢗⠄⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠠⠀⠌⠀⠌⠠⠡⠐⡀⠅⡐⢌⠠⠀⠐⠀⠄⢀⠂⡈⠄⠅⢕⢜⢌⠪⡘⡜⡼⣕⢯⢮⡪⣞⡺⣜⢵⡫⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠐⠀⠂⠠⠁⠄⡁⢂⠡⠐⡐⠨⢐⠀⡈⠀⠂⡈⠠⠐⡀⢊⠌⡢⡣⡣⡣⡣⣫⢺⣪⢳⢕⢧⢳⢝⡼⣕⢇⠂⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠠⠀⠁⡐⠀⢂⠐⡀⢂⢁⠂⠀⠅⢂⠠⠈⡀⠄⠂⡁⡐⠄⡑⢔⢕⢕⢕⢜⢎⢧⡳⣹⢪⡳⣹⢵⢝⡮⡃⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠠⠈⠠⠐⢀⠂⠔⢀⠀⡁⢂⠀⢂⠀⢂⠡⠐⠠⡁⡊⡪⡳⡹⣪⢪⢎⢧⡫⡮⡳⣝⢮⡺⣝⠎⢀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠠⠀⠄⡂⣁⢂⠢⡈⡂⡂⠢⠐⡐⢌⠠⡈⢄⢂⠡⡡⡢⡣⡣⠱⠡⡃⢗⢕⢵⢕⢯⣝⢮⢗⢏⠢⠈⠄⠀⠄⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠈⠀⠑⠈⠠⠁⠀⠂⠀⠈⠀⢀⠀⠁⡈⠈⠈⢁⠁⠁⠂⠈⠈⠐⠈⠈⠊⠩⠉⡑⢈⠊⠐⠠⠈⠀⠐⠀⠀⠀⠀⠀⠀⠀
                """;

            var encounter = new EncounterData();
            encounter.Name = "버려진 폐가";
            encounter.Description = "버려진 폐가가 보인다. 필요한 물품을 얻을 수 도 있겠지만\n묘한 기척이 느껴진다.";
            encounter.Image = ""; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "들어간다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Description = """
                                폐가엔 떠돌이 고양이가 있었다. 이녀석의 기척이었던 모양이다.
                                누군가가 남기고 간 물건을 흭득했다. [포션 +1 약초 +1]
                                """,
                                MenuText = "돌아간다",
                                Image = "",
                                Action = (player) =>
                                {

                                }
                        },
                        // 실패
                        BadResult = new EncounterResult
                        {

                                Description = """
                                버려진 집은 고블린들의 소굴이였다.
                                놈들이 덤벼온다.
                                """,
                                MenuText = "전투진입",
                                Image = "",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "들어가지 않는다",
                        GoodReulst = new EncounterResult
                        {
                                Description = "굳이 들어갈 필요는 없다.",
                                MenuText = "지나친다",
                                Image = "", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Description = "굳이 들어갈 필요는 없다.",
                                MenuText = "지나친다",
                                Image = "", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

            encounters.Add(encounter.Name, encounter);

            // ------------------------------------------------------------------------------------------------------

            encounter = new EncounterData();
            encounter.Name = "약초 스승";
            encounter.Comment = """
                약초가 필요한데..
                혹시 약초를 건네주지 않겠나?

                약초를 준다면 내 검술을 전수해주지.
                """;
            encounter.Image = ""; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "약초를 준다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Description = "약초를 받고 당신에게 검술을 전수해준다. [공격력 +5 약초 -1]",
                                Comment = "좋아 약속대로 검술을 전수해주지",
                                MenuText = "돌아간다",
                                Image = "",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 실패
                        BadResult = new EncounterResult
                        {
                                Description = "약초를 받고 당신에게 검술을 전수해준다. [공격력 -1 약초 -1]",
                                Comment = "좋아 약속대로 검술을 전수해주지",
                                MenuText = "돌아간다",
                                Image = "",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "주지 않는다",
                        GoodReulst = new EncounterResult
                        {
                                Description = """
                                "그래 이해한다. 약초는 귀중한 물건이지"
                                """,
                                MenuText = "돌아간다",
                                Image = "", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Description = """
                                "주기 싫다면 직접 빼앗아주마"
                                """,
                                MenuText = "돌아간다",
                                Image = "", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

            encounters.Add(encounter.Name, encounter);

            // ------------------------------------------------------------------------------------------------------

            encounter = new EncounterData();
            encounter.Name = "수상한 남자";
            encounter.Description = "수상해 보이는 남자가 도움을 요청한다.";
            encounter.Comment = """
                이봐 거기, 날 도와줄 수 있겠나?

                부상을 입어 움직일 수가 없군
                """;
            encounter.Image = image01; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "다가간다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Comment = "고맙군, 이거라도 받아가게",
                                Description = """
                                수상한 남자가 약초를 3개 건넸다.
                                """,
                                MenuText = "다음 지역으로",
                                Image = "",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 실패
                        BadResult = new EncounterResult
                        {
                                Comment = """
                                요즘같은 시대에
                                선행은 멍청한 짓이지
                                """,
                                Description = "남자는 산적이였다. 남자가 덤벼들어온다.",
                                MenuText = "전투개시",
                                Image = "",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "모른척 지나간다",
                        GoodReulst = new EncounterResult
                        {
                                Description = """
                                "그래 이해한다. 약초는 귀중한 물건이지"
                                """,
                                MenuText = "돌아간다",
                                Image = "", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Description = """
                                "주기 싫다면 직접 빼앗아주마"
                                """,
                                MenuText = "돌아간다",
                                Image = "", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

            encounters.Add(encounter.Name, encounter);

            // ------------------------------------------------------------------------------------------------------

            encounter = new EncounterData();
            encounter.Name = "버섯";
            encounter.Comment = """
                맛있어보이는 버섯이다.
                혹시 독이 있을까?
                """;
            encounter.Image = image03; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "먹는다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Description = "맛있다. 독은 없는 것 같다. [생명력 +10]",
                                MenuText = "다음 지역으로",
                                Image = "",
                                Action = (player) =>
                                {
                                    PlayerManager.GetInstance().GetPlayer().currentStatus.HP += 10;
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 실패
                        BadResult = new EncounterResult
                        {
                                Description = "속이 아프다... 괜히 먹은 것 같다. [생명력 -15 랜덤 디버프]",
                                MenuText = "다음 지역으로",
                                Image = "",
                                Action = (player) =>
                                {
                                    PlayerManager.GetInstance().GetPlayer().currentStatus.HP -= 15;
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 실패
                        MitigatedResult = new EncounterResult
                        {
                                Description = "아프지만 버틸만하다. [생명력 -15]",
                                MenuText = "다음 지역으로",
                                Image = "",
                                Action = (player) =>
                                {
                                    PlayerManager.GetInstance().GetPlayer().currentStatus.HP -= 15;
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "먹지 않는다",
                        GoodReulst = new EncounterResult
                        {
                                Description = "저건 분명 독버섯일거야...",
                                MenuText = "다음 지역으로",
                                Image = "", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Description = "저건 분명 독버섯일거야...",
                                MenuText = "다음 지역으로",
                                Image = "", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

            encounters.Add(encounter.Name, encounter);
        }

        public EncounterData GetRandomEncounterData()
        {
            if (encounters == null || encounters.Count == 0) Init();

            Random rand = new Random();
            int index = rand.Next(encounters.Count);
            return encounters.ElementAt(index).Value;
        }

        public EncounterData GetEncounterData(string name)
        {
            if (encounters == null || encounters.Count == 0) Init();

            if (encounters.TryGetValue(name, out EncounterData encounter))
                return encounter;

            return null;
        }
    }
}
