using UnityEngine;
using System.Collections;

namespace S3
{
	public class Item_Pickup : MonoBehaviour {

        private Item_Master itemMaster;
		public Transform ParentWhichHold;

		void OnEnable()
		{
            SetInitialReferences();
            itemMaster.EventPickupAction += CarryOutPickupActions;
		}

		void OnDisable()
		{
            itemMaster.EventPickupAction -= CarryOutPickupActions;
        }

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}

        void CarryOutPickupActions(Transform tParent)
        {
			transform.SetParent(ParentWhichHold);
            itemMaster.CallEventObjectPickup();
            transform.gameObject.SetActive(false);
        }
	}
}


