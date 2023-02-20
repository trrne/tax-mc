using System;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MySpace
{
    public class MyScript : MonoBehaviour
    {
        /// <summary>
        /// 普通の乱数生成
        /// </summary>
        protected float Randrange(float min, float max) => UnityEngine.Random.Range(min, max);

        /// <summary>
        /// float乱数生成
        /// </summary>
        protected float Randfloat(float max) => UnityEngine.Random.Range(0, max);

        /// <summary>   
        /// int乱数生成
        /// </summary>
        protected int Randint(int max) => UnityEngine.Random.Range(0, max);

        /// <summary>
        /// テスト乱数生成
        /// </summary>
        protected int Randtest(int min, int max)
        {
            System.Random r = new();
            return r.Next(min, max);
        }

        /// <summary>
        /// 配列用ランダム生成
        /// </summary>
        protected GameObject Randins(GameObject[] g, Vector3 v, Quaternion q)
        {
            int r = Randint(g.Length);
            return Instantiate(g[r], v, q);
        }

        /// <summary>
        /// 配列用ランダム生成
        /// </summary>
        protected GameObject Randins2(GameObject[] g)
        {
            int r = Randint(g.Length);
            return Instantiate(g[r]);
        }

        ///<summary>
        /// ただの生成
        ///</summary>
        public static GameObject Ins(GameObject g, Vector3 v3, Quaternion q) => Instantiate(g, v3, q);

        /// <summary>
        /// カーソル鬼ごっこ
        /// </summary>
        protected void FollowCursor(float z = 0)
        {
            var cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursor.z = z;
            transform.position = cursor;
        }

        /// <summary>
        /// 移動2D
        /// </summary>
        protected void Move2D(float s = 20, string h = "Horizontal", string v = "Vertical")
        {
            float _h = Input.GetAxis(h), _v = Input.GetAxis(v);
            var hv = new Vector3(_h, _v);
            transform.Translate(hv * s * Time.deltaTime);
        }

        /// <summary>
        /// ジャンプ2D
        /// </summary>
        protected void Jump2D(Rigidbody2D rb, float j = 5f) => rb.AddForce(Vector3.up * j, ForceMode2D.Impulse);

        /// <summary>
        /// 破壊
        /// </summary>
        protected void _Destruction(float f = 0) => Destroy(this.gameObject, f);

        /// <summary>
        /// クリックでオブジェクト取得
        /// </summary>
        protected void GetGameObject(int i = 0)
        {
            if (Input.GetMouseButtonDown(i))
            {
                Vector3 origin = transform.position, direction = new(100, 0, 0);
                RaycastHit2D hit = Physics2D.Raycast(origin, direction);

                if (hit.collider)
                {
                    var pos = hit.collider.gameObject.transform.position;
                    Debug.Log($"position:{pos}");
                }
            }
        }

        protected void Assert(bool b, string str = "") => UnityEngine.Debug.Assert(b, str);

        /// <summary>
        /// FPS表示
        /// </summary>
        protected void ComputeFps(Text t, string str = "FPS: ")
        {
            var fps = 1 / Time.deltaTime;
            var f = Mathf.Floor(fps);
            t.text = $"{str}{f}".ToString();
        }

        /// <summary>
        /// タイマー
        /// </summary>
        /// <param name="i">表示桁数</param>
        protected void Timer(Text t, int i = 0, string str = "Time: ") => t.text = $"{str}{Time.time.ToString("F" + i)}";

        /// <summary>
        /// カーソル透過
        /// </summary>
        protected void TransparentCursor(bool b = false) => UnityEngine.Cursor.visible = b;

        /// <summary>
        /// 音量調節バー
        /// </summary>
        protected void AudioSlider(AudioSource ads, float vol = .01f) => ads.volume = vol;

        protected Vector2 NewVec2(float x = 0, float y = 0) => new(x, y);

        protected Vector3 NewVec3(float x = 0, float y = 0, float z = 0) => new(x, y, z);

        /// <summary>
        /// 移動範囲制限
        /// </summary>
        protected void LimitRange(float x, float y)
        {
            Vector2 xy = new(Mathf.Clamp(this.transform.position.x, -x, x), Mathf.Clamp(this.transform.position.y, -y, y));
            transform.position = xy;
        }

        /// <summary>
        /// 日時
        /// </summary>
        protected void CurrentTime(Text t)
        {
            DateTime now = DateTime.Now;
            var current = $"{now.Hour}.{now.Minute}.{now.Second}";
            t.text = current.ToString();
        }

        /// <summary>
        /// アニメーション
        /// </summary>
        protected IEnumerator Animation(Sprite[] s, SpriteRenderer sr, float anim = .05f)
        {
            int i = 0;
            while (true)
            {
                i = i >= s.Length - 1 ? 0 : i + 1;
                sr.sprite = s[i];

                yield return new WaitForSeconds(anim);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void Sleeping(int i) => Task.Delay(i);
    }
}