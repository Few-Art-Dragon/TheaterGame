using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;



public class Referee : MonoBehaviour
{
    public static UnityEvent<GameObject> GetKindHitEvent;

    [SerializeField]
    private List<GameObject> _listSwords;


    [SerializeField]
    private float _targetTime;


    private void ClearListSword()
    {
        _listSwords.Clear();
    }
    private void GetSwordBehavior(GameObject gameObject)
    {
        AddSwordInList(gameObject);
    }

    private void AddSwordInList(GameObject gameObject)
    {
        if(_listSwords.Count < 2)
        {
            _listSwords.Add(gameObject);
        }
    }

    private void ComparerSwordsBehavior()
    {
        var player = _listSwords[0].gameObject.GetComponent<Player>();
        var enemy = _listSwords[1].gameObject.GetComponent<Enemy>();

        if((int)player.swordBehavior == -1 & (int)enemy.swordBehavior == 1 )
        {

        }
        else if((int)player.swordBehavior == 1 & (int)enemy.swordBehavior == -1 )
        {

        }
        else if((int)player.swordBehavior > (int)enemy.swordBehavior)
        {

        }
        else if((int)player.swordBehavior < (int)enemy.swordBehavior)
        {

        }
        else if((int)player.swordBehavior == (int)enemy.swordBehavior)
        {

        }
        
    }

    private async void Timer()
    {
        var time = 0f;

        while(time < 3f)
        {
            time += Time.deltaTime/3;
            Debug.Log(time);
        }

        await Task.Yield();
    }

    private void Output()
    {
        
        foreach (var value in _listSwords)
        {
            Debug.Log(value.name);
        }
    }


    private void SetStandartParam()
    {
        
        
    }

    private void StartStandartFunctions()
    {
        
    }
    private void OnEnable()
    {
        _listSwords = new List<GameObject>();
        ClearListSword();
        GetKindHitEvent = new UnityEvent<GameObject>();
        GetKindHitEvent.AddListener(GetSwordBehavior);
    }

    private void Awake()
    {
        
    }

    void Start()
    {
        SetStandartParam();
        StartStandartFunctions();

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ITimer(_targetTime));
            // ComparerSwordsBehavior();
            // Output();
        }
        Output();
    }

    IEnumerator ITimer(float sec)
    {
        yield return new WaitForSeconds(sec);
        try
        {
            for(int i = 0; i < _listSwords.Count; i++)
            {
                _listSwords[i].GetComponent<Player>().MoveSwordOnTargetPositionEvent.Invoke();
            }
        }
        catch (System.Exception)
        {

            
        }
    }
}
