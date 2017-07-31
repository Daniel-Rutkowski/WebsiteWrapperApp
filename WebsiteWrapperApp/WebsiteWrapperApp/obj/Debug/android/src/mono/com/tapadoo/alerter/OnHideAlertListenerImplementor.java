package mono.com.tapadoo.alerter;


public class OnHideAlertListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.tapadoo.alerter.OnHideAlertListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onHide:()V:GetOnHideHandler:Com.Tapadoo.Alerter.IOnHideAlertListenerInvoker, Alerter\n" +
			"";
		mono.android.Runtime.register ("Com.Tapadoo.Alerter.IOnHideAlertListenerImplementor, Alerter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnHideAlertListenerImplementor.class, __md_methods);
	}


	public OnHideAlertListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OnHideAlertListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Tapadoo.Alerter.IOnHideAlertListenerImplementor, Alerter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onHide ()
	{
		n_onHide ();
	}

	private native void n_onHide ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
