﻿using System;
using System.Text;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.ServerMods.WorldEdit;

namespace Vintagestory.GameContent
{
    public class ItemMagicWand : Item
    {
        ICoreServerAPI sapi;

        public override void OnLoaded(ICoreAPI api)
        {
            if (api.Side == EnumAppSide.Server)
            {
                sapi = api as ICoreServerAPI;
            }
            base.OnLoaded(api);
        }

        public override void OnHeldAttackStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, ref EnumHandHandling handling)
        {
            if (byEntity.World.Side == EnumAppSide.Server)
            {
                IServerPlayer plr = (byEntity as EntityPlayer).Player as IServerPlayer;
                if (plr != null)
                {
                    sapi.ModLoader.GetModSystem<WorldEdit>().OnAttackStart(plr, blockSel);
                }
            }

            handling = EnumHandHandling.PreventDefaultAction;
            base.OnHeldAttackStart(slot, byEntity, blockSel, entitySel, ref handling);
        }

        public override void OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            if (byEntity.World.Side == EnumAppSide.Server)
            {
                IServerPlayer plr = (byEntity as EntityPlayer).Player as IServerPlayer;
                if (plr != null)
                {
                    sapi.ModLoader.GetModSystem<WorldEdit>().OnInteractStart(plr, blockSel);
                }
            }

            handling = EnumHandHandling.PreventDefaultAction;
            base.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        public override bool OnHeldAttackStep(float secondsPassed, ItemSlot slot, EntityAgent byEntity, BlockSelection blockSelection, EntitySelection entitySel)
        {
            return base.OnHeldAttackStep(secondsPassed, slot, byEntity, blockSelection, entitySel);
        }

        public override void OnHeldAttackStop(float secondsPassed, ItemSlot slot, EntityAgent byEntity, BlockSelection blockSelection, EntitySelection entitySel)
        {
            base.OnHeldAttackStop(secondsPassed, slot, byEntity, blockSelection, entitySel);
        }
    }
}
