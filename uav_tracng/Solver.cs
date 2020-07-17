using System;
using System.Linq;

namespace uav_tracng
{
    public class Solver
    {
        public double dist_Ant;    //расстояние соединения муравья
        int kol_it;
        public int[] matrix_sol_con;  //текущий путь для муравья
        public int[] matrix_res_con;    //возможные вершины для муравья
        public int q;   //количество пройденных вершин муравьём
        public int z;   //количество муравььёв
        public double[,] matrix_sol_con_vero;   //текущая вероятность перехода муравья
        public double[,] matrix_sol_fero;       //текущее значение феромона на пути
        double vero;
        public int[,] matr_w;  //текущий путь для муравья
        public int[,] matrix_numeric_con;   //матрица нумерации соединений
        public double crossEstimatePut;    // значение перекрёстных помех для пути
        public double crossEstimate_Ant;    // значение перекрёстных помех для муравья
        public int w; //вместимость канала
        public int m;   // количество соединений
        public int n;   // количество устройств
        public int[,] matrix_x = new int[0, 0]; //матрица перекрёстных помех
        public int[,] matrix_conn = new int[0, 0]; //матрица соединений
        public double[,] matrix_chan = new double[0, 0];//матрица каналов
        public double crossEstimate;    // значение перекрёстных помех для проекта
        public int[,] matrix_y; //матрица пути каждого соединения
        public int[] matrix_kol_versh_v_soed;   //матрица количества вершин в каждом соединении
        public double[] dist_put_all;   //матрица длины пути
        public Solver() { }
        public void get_solution()
        {
            crossEstimate = 0;
            Random rand = new Random();
            matrix_kol_versh_v_soed = new int[m];
            matrix_y = new int[m, n];
            matr_w = new int[n, n];
            dist_put_all = new double[m];
            matrix_numeric_con = new int[m, 2];

            set_numeric_con();
            for (int i = 0; i < m; i++) //цикл для соединений
            {
                int kil = 0;
                z = 2;  //количество муравьёв
                matrix_sol_fero = new double[n, n];
                crossEstimatePut = 1000000;
                dist_put_all[i] = 100000;
                set_default_fero();
                for (int j = 0; j < z; j++) // цикл для муравьёв
                {
                    matrix_sol_con_vero = new double[n, n];
                    matrix_sol_con = new int[n];
                    set_matrix_sol_con();
                    q = 0;  //счётчик пройденных вершин для муравья
                    dist_Ant = 0;
                    crossEstimate_Ant = 0;
                    matrix_sol_con[q] = matrix_numeric_con[i, 0]; //установка текущей вершины =вершина отправки

                    for (kol_it = 0; matrix_sol_con[q] != matrix_numeric_con[i, 1] && kol_it < n; kol_it++)   //пока текущая вершина не вершина назначения
                    {

                        matrix_res_con = new int[n];
                        double sum = 0;
                        int versh = 0;
                        vero = rand.NextDouble();
                        for (int l = 0; l < n; l++)//все веришны перебираются
                        {
                            if (matrix_sol_fero[matrix_sol_con[q], l] != 0 && !matrix_sol_con.Contains(l) && matr_w[matrix_sol_con[q], l] + matr_w[l, matrix_sol_con[q]] <= w)
                            //выбираются те, с кем у текущей вершины есть канал, но при этом не образующий цикл пути муравья
                            {
                                matrix_res_con[l] = 1;  //устанавливаются допустимые вершины 
                                sum += set_sol_con_vero(matrix_sol_con[q], l, i);
                                versh++;//суммируется сумма вероятностей
                            }
                        }
                        if (versh != 0)
                        {
                            for (int ert = 0; ert < n; ert++)   //все веришны перебираются
                            {
                                if (matrix_res_con[ert] == 1)
                                {
                                    matrix_sol_con_vero[matrix_sol_con[q], ert] = set_sol_con_vero(matrix_sol_con[q], ert, i) / sum; //устанавливается вероятность перехода в эту вершину
                                    if (vero - matrix_sol_con_vero[matrix_sol_con[q], ert] < 0)   //если по отрезку выпала эта вершина
                                    {
                                        dist_Ant += (matrix_chan[matrix_sol_con[q], ert] + matrix_chan[ert, matrix_sol_con[q]]);    //суммируем значение пути для текущего муравья   
                                        q++;                    //инкрементируем значение пути
                                        matrix_sol_con[q] = ert;  //устанавливаем вершину, в которую перешёл муравей
                                        break;  //переход к точке инкрементации кол ит
                                    }
                                    else vero -= matrix_sol_con_vero[matrix_sol_con[q], ert]; //если по отрезку не выпала, то уменьшаем значение вероятности на текущий отрезок
                                }
                            }
                        }
                    }
                    if(matrix_sol_con[q] == matrix_numeric_con[i, 1])
                    {
                        if (i == 0) //если это первое соединение
                        {
                            crossEstimatePut = 0;   //уставнавливаем значение перекрёстных помех для текущего соединения=0
                            if (dist_put_all[i] > dist_Ant)    //если путь текущего муравья меньше установленного минимального
                            {
                                matrix_kol_versh_v_soed[i] = q + 1; //то записываем этого муравья в матрицу количества вершин
                                for (int l = 0; l < q + 1; l++) //записываем текущий путь муравья в матрицу пути
                                {
                                    matrix_y[i, l] = matrix_sol_con[l];
                                }   //устнавливаем значение пути текущего муравья новым минимальным
                                dist_put_all[i] = dist_Ant;
                            }
                        }
                        else
                        {           //если же это не первая вершина
                            for (int l = 0; l < i; l++) //перебираем по всем соединениям до текущего
                            {
                                if (matrix_x[i, l] == 1 || matrix_x[l, i] == 1) //если в матрице совместимости текущее соединение не совместимо с другим
                                {
                                    for (int f = 0; f < q; f++) //перебираем текущий путь по всем парам переходов(каналов)
                                    {
                                        for (int z = 0; z < matrix_kol_versh_v_soed[l] - 1; z++)  //перебираем путь, с которым есть несовместимость по всем парам переходов(каналов)
                                        {
                                            if ((matrix_y[l, z] == matrix_sol_con[f] && matrix_y[l, z + 1] == matrix_sol_con[f + 1]) //если в уже построенных путях есть совпадения по паре вершин
                                                || (matrix_y[l, z] == matrix_sol_con[f + 1] && matrix_y[l, z + 1] == matrix_sol_con[f]))
                                            {
                                                crossEstimate_Ant += (matrix_chan[matrix_sol_con[f], matrix_sol_con[f + 1]] + matrix_chan[matrix_sol_con[f + 1], matrix_sol_con[f]]); //суммируем текущее значение перекрёстных 
                                                                                                                                                                                      //помех для муравья с длиной данного параллельного участка
                                            }
                                        }
                                    }
                                }
                            }
                            if (crossEstimate_Ant == 0 && crossEstimatePut == 0)    //если же это не первая вершина и если минимальное значение перекрёстных помех для соединения и текущего муравья равно нулю:
                            {
                                if (dist_put_all[i] > dist_Ant)        //если путь муравья оказался меньше минимального
                                {
                                    dist_put_all[i] = dist_Ant;            //устанавливаем новый минимальный путь
                                    matrix_kol_versh_v_soed[i] = q + 1;  //то записываем этого муравья в матрицу количества вершин
                                    for (int l = 0; l < q + 1; l++)     //записываем текущий путь муравья в матрицу пути
                                    {
                                        matrix_y[i, l] = matrix_sol_con[l];
                                    }
                                }
                            }
                            else if (crossEstimate_Ant == 0)        //если же значение перекрёстных помех муравья равно нулю, а минимальное для текущего соединения не равно нулю, то
                            {
                                crossEstimatePut = crossEstimate_Ant;   ////устанавливаем новое минимальное значение перекрёстных помех 
                                dist_put_all[i] = dist_Ant;     ////устанавливаем новый минимальный путь
                                matrix_kol_versh_v_soed[i] = q + 1; ////то записываем этого муравья в матрицу количества вершин
                                for (int l = 0; l < q + 1; l++)     //записываем текущий путь муравья в матрицу пути
                                {
                                    matrix_y[i, l] = matrix_sol_con[l];
                                }
                            }
                            else if (crossEstimatePut == 0) { }   //если же минимальное значение перекрёстных помех равно нулю, а у текущего муравья-нет, то забываем про этого муравья
                            else //если же это не первая вершина и если ни одно из сравниваемых значений не равно нулю
                            {
                                if (crossEstimatePut * dist_put_all[i] > crossEstimate_Ant * dist_Ant) //сравниваем показатели качества пути 
                                {
                                    crossEstimatePut = crossEstimate_Ant;   ////устанавливаем новое минимальное значение перекрёстных помех 
                                    dist_put_all[i] = dist_Ant; ////устанавливаем новый минимальный путь
                                    matrix_kol_versh_v_soed[i] = q + 1; ////то записываем этого муравья в матрицу количества вершин
                                    for (int l = 0; l < q + 1; l++) //записываем текущий путь муравья в матрицу пути
                                    {
                                        matrix_y[i, l] = matrix_sol_con[l];
                                    }
                                }
                            }
                        }
                        if (j < z - 1) //если текущий муравей не последний
                        {
                            for (int oprt = 0; oprt < n; oprt++)    //устанавливаем новое значение феромона для всех вершин
                            {
                                for (int zprt = 0; zprt < n; zprt++)
                                {
                                    if (matrix_sol_fero[oprt, zprt] != 0) { matrix_sol_fero[oprt, zprt] *= 0.5; }

                                }
                            }
                            for (int f = 0; f < q; f++)
                            {
                                matrix_sol_fero[matrix_sol_con[f], matrix_sol_con[f + 1]] += 1 / (matrix_chan[matrix_sol_con[f + 1], matrix_sol_con[f]] + matrix_chan[matrix_sol_con[f], matrix_sol_con[f + 1]]);
                            }
                        }
                    }
                    else
                    {
                        if( kil < 100) { j--; kil++; }
                    }
                }
                for (int z = 0; z < matrix_kol_versh_v_soed[i] - 1; z++)  //перебираем путь
                {
                    matr_w[matrix_y[i, z], matrix_y[i, z + 1]]++;
                }
                crossEstimate += crossEstimatePut;  //суммирование значения перекрёстных помех для проекта
            }
        }
        public void set_matrix_sol_con()
        {
            for (int i = 0; i < n; i++)
            {
                matrix_sol_con[i] = -1;
            }
        }
        public void set_default_fero() //установка начального значения феромона
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (matrix_chan[i, j] != 0) { matrix_sol_fero[i, j] = matrix_sol_fero[j, i] = 0.5; }
                }
            }
        }
        public void set_numeric_con() //занесение в матрицу нумерации соединений всех соединений из матрицы соединений
        {
            int i = 0;
            for (int l = 0; l < n; l++)
            {
                for (int h = l + 1; h < n; h++)
                {
                    if (matrix_conn[l, h] != 0)
                    {
                        matrix_numeric_con[i, 0] = l;
                        matrix_numeric_con[i, 1] = h;
                        i++;
                    }
                }
            }
        }
        public double set_sol_con_vero(int i, int j, int soed)    //расчёт t перехода из вершины i в вершину j
        {
            for (int r = 0; r < soed; r++) //по всем соединениям до текущего
            {
                for (int s = 0; s < matrix_kol_versh_v_soed[r] - 1; s++)    //все пары вершин которые вошли в путь r
                {
                    if (matrix_x[r, soed] == 1 || matrix_x[soed, r] == 1)    //если по матрице совместимости эти соединения не совместимы
                    {
                        if ((matrix_y[r, s] == i && matrix_y[r, s + 1] == j) || (matrix_y[r, s + 1] == j && matrix_y[r, s] == i))     //если подобный путь уже был
                        {
                            return (((1 / ((matrix_chan[i, j] + matrix_chan[j, i]) * (matrix_chan[i, j] + matrix_chan[j, i])) + 1)) * matrix_sol_fero[i, j]) / (matrix_chan[i, j] + matrix_chan[j, i]);
                        }
                    }
                }
            }
            return (((1 / ((matrix_chan[i, j] + matrix_chan[j, i]) * 1 + 1)) * matrix_sol_fero[i, j]) / (matrix_chan[i, j] + matrix_chan[j, i]));
        }
    }
}
